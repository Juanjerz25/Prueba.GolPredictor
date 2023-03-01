import { Injectable } from "@angular/core";
import { Observable, Observer } from 'rxjs';
import { AnonymousSubject } from 'rxjs/internal/Subject';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from "src/enviroments/environment";
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';

const CHAT_URL = `ws://${environment.backend}/"`;

export interface Message {
    source: string;
    content: string;
}



@Injectable()
export class WebsocketService {
    private subject: AnonymousSubject<MessageEvent>;
    public messages: Subject<Message>;


    private dataSubject = new Subject<any>();
    public data$ = this.dataSubject.asObservable();
    private socket$: WebSocketSubject<any>;
    constructor() {
    }

    public connect(action: any): void {
      this.socket$ = webSocket(`${environment.ws}/WebSocketHandler/Socket?action=${action}`);
      this.socket$.subscribe(
        (data) => {
          //console.log(data.Result);
          this.dataSubject.next(data.Result);
        },
        (error) => {
          console.error(error);
        }
      );
    }

    public send(data: any): void {
      this.socket$.next(data);
    }

    public close(): void {
      this.socket$.complete();
    }

    // public StartSocket(action:string){
    //   this.messages = <Subject<Message>>this.connect(`ws://${environment.backend}/"WebSocketHandler/Socket?action=${action}`).pipe(
    //     map(
    //         (response: MessageEvent): Message => {
    //             console.log(response.data);
    //             let data = JSON.parse(response.data)
    //             return data;
    //         }
    //     )
    // );
    // }

    // public connect(url:any): AnonymousSubject<MessageEvent> {
    //     if (!this.subject) {
    //         this.subject = this.create(url);
    //         console.log("Successfully connected: " + url);
    //     }
    //     return this.subject;
    // }

    // private create(url:any): AnonymousSubject<MessageEvent> {
    //     let ws = new WebSocket(url);
    //     let observable = new Observable((obs: Observer<MessageEvent>) => {
    //         ws.onmessage = obs.next.bind(obs);
    //         ws.onerror = obs.error.bind(obs);
    //         ws.onclose = obs.complete.bind(obs);
    //         return ws.close.bind(ws);
    //     });
    //     let observer = {
    //         error: null,
    //         complete: null,
    //         next: (data: Object) => {
    //             console.log('Message sent to websocket: ', data);
    //             if (ws.readyState === WebSocket.OPEN) {
    //                 ws.send(JSON.stringify(data));
    //             }
    //         }
    //     } as any;
    //     return new AnonymousSubject<MessageEvent>(observer, observable);
    // }

    // public getMessageSubject(): Subject<any> {
    //   return this.messageSubject;
    // }



}

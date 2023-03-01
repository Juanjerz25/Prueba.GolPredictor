import { PartidoDto } from "./partido-dto";
import { SesionUsuarioDto } from "./sesion-usuario-dto";

export interface SesionDto {
    id: number;
    nombre: string;
    entryCode: string;
    partidoId: number | null;
    status: boolean | null;
    partido: PartidoDto;
    sesionUsuario: SesionUsuarioDto[];
}

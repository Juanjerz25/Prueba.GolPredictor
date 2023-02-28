import { PaisDto } from "./pais-dto";

export interface PartidoDto {
  id: number;
  team1Id: number | null;
  team2Id: number | null;
  fechaInicio: Date | null;
  fechaFin: Date | null;
  status: boolean | null;
  resultTeam1: number | null;
  resultTeam2: number | null;
  team1: PaisDto;
  team2: PaisDto;
}

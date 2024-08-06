import { Province } from 'src/app/core/models/Province';
export interface Country {
  id: number;
  name: string;
  provinces: Province[];
}

import { Author } from "../model/Author";
import { Genre } from "../model/Genre";

export interface DtoBook {
  id?: number;
  title: string;
  description?: string;
  image?: string;
  releaseDate: Date;
  authors: Author[];
  genres: Genre[];
}

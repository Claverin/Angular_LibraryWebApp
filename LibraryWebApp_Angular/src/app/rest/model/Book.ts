import { Author } from "./Author";
import { Genre } from "./Genre";

export interface Book {
    id: number;
    title: string;
    description: string;
    image: string;
    releaseDate: Date;
    authors: Author[];
    genres: Genre[];
}

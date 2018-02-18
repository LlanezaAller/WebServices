export interface Album {
    artist : any;
    uri : string;
    id : string;
    name : string;
    images : {
        height: string,
        width: string;
        url: string;
    }[];
}
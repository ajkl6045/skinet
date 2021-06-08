import { IProduct } from './product';

export interface IPaginaion {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];
}

export class Pagination implements IPaginaion {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[] = [];
}

import { EntitiesResponse } from "./EntitiesResponse";


export class PagedResponse<Type> extends EntitiesResponse<Type> {
  public TotalCount: number;
};

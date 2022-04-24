import { BaseResponse } from "./BaseResponse";

export interface EntitiesResponse<Type> extends BaseResponse {
  Entities: Array<Type>;
};

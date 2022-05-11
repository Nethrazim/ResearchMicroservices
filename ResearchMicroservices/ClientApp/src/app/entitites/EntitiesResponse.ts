import { BaseResponse } from "./BaseResponse";

export class EntitiesResponse<Type> extends BaseResponse {
  Entities: Array<Type>;
};

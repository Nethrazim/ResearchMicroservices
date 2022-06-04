import { BaseResponse } from "./BaseResponse";

export class EntitiesResponse<Type> extends BaseResponse {
  Entity: Array<Type>;
};

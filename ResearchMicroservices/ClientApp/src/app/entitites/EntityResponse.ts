import { BaseResponse } from "./BaseResponse";

export class EntityResponse<Type> extends BaseResponse {
  Entity: Type;
};

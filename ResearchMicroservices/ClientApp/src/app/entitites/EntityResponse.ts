import { BaseResponse } from "./BaseResponse";

export interface EntityResponse<Type> extends BaseResponse {
  Entity: Type;
};

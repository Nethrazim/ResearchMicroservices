import { BaseResponse } from "./BaseResponse";

export class ValueResponse<Type> extends BaseResponse {
  Value: Type;
};

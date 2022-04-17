import { BaseResponse } from "./BaseResponse";
import { Token } from "./Token";

export interface AuthenticateResponse extends BaseResponse {
  Entity: Token
}

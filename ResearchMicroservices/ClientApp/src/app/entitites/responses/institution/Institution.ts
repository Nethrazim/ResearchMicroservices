import { Address } from "./Address";
import { Contact } from "./Contact";

export class Institution {
  Id: number;
  Name: string;
  AdminId: string;
  IsActive: boolean;
  CreatedDate: string;
  UpdatedDate: string;
  Contact: Contact;
  Address: Address;
}

import { Contact } from "../../../components/admin/admin-manage-contacts/admin-manage-contacts.component";
import { Address } from "./Address";

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

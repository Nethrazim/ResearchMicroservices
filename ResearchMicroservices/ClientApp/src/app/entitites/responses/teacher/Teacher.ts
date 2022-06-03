import { Institution } from "../institution/Institution";

export class Teacher {
  public Id: number;
  public InstitutionId: number;
  public FirstName: string;
  public MiddleName: string;
  public LastName: string;
  public Gender: boolean;
  public Institution: Institution
}

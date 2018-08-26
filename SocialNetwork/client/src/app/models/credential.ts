import { Profile } from "./profile";

export class Credential {
    id: number;
    email: string;
    password: string;
    profile: Profile;
    dateRegistration: string;
  }
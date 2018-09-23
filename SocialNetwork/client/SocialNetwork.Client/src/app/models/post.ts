import { Profile } from './profile';

export interface Post {
  id: number;
  text: string;
  datetime: Date;
  profile: Profile;
}

import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { RegistrationService } from '../../services/registration/registration.service';



@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  public user = new User();
  constructor(private registrationService: RegistrationService) {}

  ngOnInit() {
  }

  onSubmit() {

          this.registrationService.sendEmail(this.user).subscribe((response: string) => alert(response));
  }



}

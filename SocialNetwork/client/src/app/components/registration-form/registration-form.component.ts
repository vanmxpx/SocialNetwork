import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationService } from '../../services/registration/registration.service';
import { AuthenticationService } from '../../services/security/authentication.service';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  public user = new User();
  // private router: Router;
  // private route: ActivatedRoute;
  // returnUrl: string;
  constructor(
    private registrationService: RegistrationService,
    public snackBar: MatSnackBar,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {

  }

  onSubmit() {

    this.registrationService.sendEmail(this.user).subscribe(
      (response: string) => {
        this.snackBar.open(response, undefined, { duration: 50000 });
        console.log(response);
      }
    );


}



}

import { Component, OnInit } from '@angular/core';
import { Profile } from '../../models/profile';
import { ProfileService } from '../../services/model-services/profile.service';
import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';

@Component({
    selector: 'app-settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
    selectedAvatarImage: File = null;
    public progress: number;
    public message: string;
    public profile;

    onFileSelected(event) {
        this.selectedAvatarImage = <File>event.target.files[0];
        console.log(this.selectedAvatarImage.name);
    }

    uploadFile() {
        this.profileService.uploadAvatar(this.selectedAvatarImage).subscribe(event => {
            if (event.type === HttpEventType.UploadProgress) {
                this.progress = Math.round(100 * event.loaded / event.total);
            } else if (event.type === HttpEventType.Response) {
                this.message = event.body.toString();
            }
        }
        );
    }

    constructor(private profileService: ProfileService,
        private http: HttpClient) {

    }

    ngOnInit() {
        this.getProfile();
    }

    public getProfile(): void {
        this.profileService.getProfile(JSON.parse(localStorage.getItem('login')))
            .subscribe(
                profile => {
                    this.profile = profile;
                    localStorage.setItem('profile', JSON.stringify(this.profile));
                }
            );
    }
}

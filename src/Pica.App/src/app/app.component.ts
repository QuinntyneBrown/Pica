import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Profile } from './@api/models';
import { ProfileService } from './@api/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public form: FormGroup = new FormGroup({
    firstname: new FormControl(null,[Validators.required]),
    lastname: new FormControl(null,[Validators.required]),
    imageUrl: new FormControl(null,[Validators.required]),
    companyImageUrl: new FormControl(null,[Validators.required])
  });

  public imageUploadControl = new FormControl(null,[]);

  public companyImageUploadControl = new FormControl(null,[]);

  constructor(
    private readonly _profileService: ProfileService
  ) {

  }

  public ngOnInit() {
    this.imageUploadControl
    .valueChanges
    .pipe(

    ).subscribe();

    this.companyImageUploadControl
    .valueChanges
    .pipe(

    ).subscribe();
  }

  public create(profile: Profile) {
    this._profileService.create({ profile })
    .subscribe();
  }

  public update(profile: Profile) {
    this._profileService.update({ profile })
    .subscribe();
  }
}

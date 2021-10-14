import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ImageUploadModule } from '@shared/image-upload/image-upload.module';
import { baseUrl } from '@core/constants';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ImageUploadModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: baseUrl, useValue: "https://localhost:5001/"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

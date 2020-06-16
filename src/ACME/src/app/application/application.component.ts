import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { AppService } from '../app.service';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss'],
})
export class ApplicationComponent implements OnInit {
  form: FormGroup;
  countries$: Observable<string[]>;
  states$: Observable<string[]>;

  constructor(private fb: FormBuilder, private appService: AppService) {
    this.countries$ = this.appService.getCountryNames();
    this.states$ = this.appService.getStates();
  }

  ngOnInit(): void {
    this.buildForm();

    this.field('country').valueChanges.subscribe((value) => {
      const state = this.field('state');
      const postcode = this.field('postcode');
      if (value === 'Australia') {
        state.setValidators(Validators.required);
        postcode.setValidators(Validators.required);
        postcode.updateValueAndValidity();
      } else {
        state.markAsPristine();
        state.clearValidators();
        postcode.markAsPristine();
        postcode.markAsUntouched();
        postcode.clearValidators();
      }
    });

    this.field('state').valueChanges.subscribe((_) => {
      console.log('state : ', this.field('state'));
    });
  }

  private field(filedName: string): AbstractControl {
    return this.form.get(filedName);
  }

  private buildForm() {
    this.form = this.fb.group({
      country: [undefined, Validators.required],
      state: [undefined],
      postcode: [undefined],
      fullname: [undefined, [Validators.required, Validators.maxLength(120)]],
    });
  }

  submit() {
    console.log('form : ', this.form.value);
    if (this.form.valid) {
      this.appService
        .postApplicationForm(this.form.value)
        .pipe(
          catchError((error) => {
            alert(error.error.error);
            return throwError(error);
          })
        )
        .subscribe((result) => {
          console.log('application submitted successfully ... ', result);
        });
    }
  }

  numericKeysOnly(event): boolean {
    const charCode = event.which ? event.which : event.keyCode;
    if (charCode >= 48 && charCode <= 57) {
      return true;
    }
    return false;
  }
}

import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { AppService } from '../app.service';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, filter } from 'rxjs/operators';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  form: FormGroup;
  countries$: Observable<string[]>;
  states$: Observable<string[]>;
  submitted = false;
  applicationNo: number = undefined;

  constructor(private fb: FormBuilder, private appService: AppService) {
    this.countries$ = this.appService.getCountryNames();
    this.states$ = this.appService.getStates();
  }

  ngOnInit(): void {
    this.buildForm();

    const stateField = this.field('state');
    const postcodeField = this.field('postcode');

    this.field('country').valueChanges.subscribe((value) => {
      if (value === 'Australia') {
        stateField.setValidators(Validators.required);
        postcodeField.setValidators([
          Validators.required,
          Validators.maxLength(4),
          Validators.minLength(4),
        ]);
        postcodeField.updateValueAndValidity();
      } else {
        stateField.markAsPristine();
        stateField.clearValidators();
        postcodeField.markAsPristine();
        postcodeField.markAsUntouched();
        postcodeField.clearValidators();
      }
    });

    stateField.valueChanges.subscribe((val) => {
      const postcode = postcodeField.value;
      if (postcode) {
        this.validatePostcode(val, postcode);
      }
    });

    postcodeField.valueChanges
      .pipe(filter((val) => !!val && val.length === 4))
      .subscribe((val) => {
        const state = stateField.value;
        if (state) {
          this.validatePostcode(state, val);
        }
      });
  }

  private validatePostcode(state: string, postcode: string) {
    const postcodeField = this.field('postcode');

    this.appService
      .validatePostcode(state, postcode)
      .pipe(
        catchError((error) => {
          return throwError(error);
        })
      )
      .subscribe((result) => {
        console.log('result : ', result);
        if (!result) {
          postcodeField.setErrors({
            invalid: `Postcode must be a valid Australian postcode (not exists in db)`,
          });
        } else {
          postcodeField.setErrors(null);
        }
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
          this.applicationNo = result;
          this.submitted = true;
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

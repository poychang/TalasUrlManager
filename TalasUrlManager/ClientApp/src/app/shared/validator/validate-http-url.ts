import {AbstractControl, FormControl, ValidatorFn} from '@angular/forms';

export function validateHttpUrl(control: FormControl) {
  const HTTP_URL_REGEXP =
    /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/;
  const isValid = HTTP_URL_REGEXP.test(control.value);
  return isValid ? null : { invalidHttpUrl: { valid: false } };
}

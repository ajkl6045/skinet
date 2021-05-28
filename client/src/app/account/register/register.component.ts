import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
registerForm: FormGroup;
errors: string[];
// aa = 1;
  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
   // if (this.aa === 1) {
    //  this.router.navigateByUrl('/');
   // }
    this.createRegisterForm();
  }
  createRegisterForm() {
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null,
        [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
        [this.validateEmailNotTaken()]
      ],
      password: [null, [Validators.required]]
    });
  }

  onSubmit() {
   // console.log(this.registerForm.value);
    this.accountService.register(this.registerForm.value).subscribe(() => {
      // console.log('user logged in');
      this.router.navigateByUrl('/shop');
     }, error => {
      console.log(error);
      this.errors = error.errors;
     });
  }
  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? { emailExists: true } : null;
            })
          );
        })
      );
    };
  }

}

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../../../models/user.model';
import { Schooling } from '../../../models/schooling.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { SchoolingService } from '../../../services/schooling.service';
import { HeaderService } from '../../template/header/header.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  userForm: FormGroup;
  user: User;
  schooling: Schooling[];
  id!: string;
  UserId: string;
  currentDate: any;
  maxDate: Date;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private userService: UserService,
    private schoolingService: SchoolingService,
    private router: Router,
    private headerService: HeaderService
  ) {

    headerService.headerData = {
      title: 'Novo Usuário',
      icon: 'person_add',
      routeUrl: '/user'
    }
  }

  ngOnInit(): void {

    this.id = this.route.snapshot.params['id'];

    this.userForm = this.formBuilder.group({
      id: [0],
      nome: ['', [Validators.required, Validators.min(2), Validators.max(50), Validators.pattern('[a-zA-Z ]*')]],
      sobrenome: ['', [Validators.required, Validators.min(2), Validators.max(100), Validators.pattern('[a-zA-Z ]*')]],
      email: ['', [Validators.required, Validators.email, Validators.max(100)]],
      dataNascimento: ['', Validators.required],
      escolaridadeId: ['', Validators.required],
    });

    this.schoolingService.get()
      .subscribe(res => this.schooling = res);

    if (this.id) {
      this.userService.getById(this.id)
        .subscribe(res => {
          this.userForm.patchValue(res)
          var date = this.userForm.controls['dataNascimento'].value;
          this.userForm.controls['dataNascimento'].setValue(date.substring(0, 10));
        });
    }
  }

  createOrUpdateUser(): void {

    if (this.userForm.valid) {

      if (!this.id) {
        this.userService.save(this.userForm.value).subscribe(() => {
          this.userService.showMessage("Usuário Inserido")
          this.router.navigate(['/user'])
        });

      } else {
        this.userService.update(this.userForm.value, this.id).subscribe(() => {
          this.userService.showMessage("Usuário Alterado")
          this.router.navigate(['/user'])
        });
      }

    } else {
      this.userForm.markAllAsTouched();
    }
  }

  cancel(): void {

    this.router.navigate(['/user'])

  }

}

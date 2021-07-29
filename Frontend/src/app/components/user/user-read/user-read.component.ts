import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../../services/user.service'
import { User } from '../../../models/user.model'
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

import { PopUpDeleteComponent } from 'src/app/shared/pop-up-delete/pop-up-delete.component';


@Component({
  selector: 'app-user-read',
  templateUrl: './user-read.component.html',
  styleUrls: ['./user-read.component.css']
})
export class UserReadComponent implements OnInit {

  key: string;
  value: string;

  veiculos: User[];
  displayedColumns = ['nome', 'sobrenome', 'email', 'dataNascimento', 'escolaridade', 'action']
  dataSource = null;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private userService: UserService, private router: Router, public dialog: MatDialog) { }
  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.veiculos);
    this.dataSource.sort = this.sort;
    this.userService.get().subscribe(res => {
      this.veiculos = res;
      this.dataSource.data = res;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  updateUser(id) {

    this.router.navigate(['/user/update', id])

  }

  deleteUser(id) {
    const dialogRef = this.dialog.open(PopUpDeleteComponent, { width: '200px' });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 1) {
        this.userService.delete(id).subscribe(() => {
          this.userService.showMessage("Usuário Deletado")
          this.ngOnInit();
        });
      }
    });
  }

}

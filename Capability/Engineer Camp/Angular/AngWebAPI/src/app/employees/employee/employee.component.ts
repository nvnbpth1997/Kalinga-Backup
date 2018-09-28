import { EmployeeService } from './../shared/employee.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from "@angular/forms";

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private emp: EmployeeService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }

    this.emp.selectedEmployee = {
      EmployeeID : null,
      FirstName : '',
      LastName : '',
      Designation : ''
    };
  }

  submitForm(form: NgForm) {
    if (form.value.EmployeeID == null) {
    this.emp.postEmployee(form.value).subscribe(data => {
    this.resetForm(form);
    this.emp.getEmployee();
       alert('New Record Added Successfully');
      }
   ); } else {
      this.emp.putEmployee(form.value.EmployeeID, form.value)
     .subscribe(data => {
       this.resetForm(form);
       this.emp.getEmployee();
       alert('Record updated successfully');
     });
   }
}
}

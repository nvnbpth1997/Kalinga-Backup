import { EmployeeService } from './../../shared/employee.service';
import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/employees/shared/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private emp: EmployeeService) { }

  ngOnInit() {
    this.emp.getEmployee();
  }

  showForEdit(employee: Employee) {
    this.emp.selectedEmployee = Object.assign({}, employee);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?') === true) {
      this.emp.deleteEmployee(id)
      .subscribe(x => {
        this.emp.getEmployee();
        alert('Deleted Successfully!');
      });
    }
  }
}

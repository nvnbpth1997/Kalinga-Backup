import { Employee } from 'src/app/employees/shared/employee';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  selectedEmployee: Employee;
  employeelist: Employee[];
  constructor(private http: HttpClient) { }

  postEmployee(employee: Employee) {
    // const body = JSON.stringify(employee);
    // const headerOptions = new Headers({'Content-Type': 'application/json'});
    // const requestOptions = new RequestOptions({method: RequestMethod.Post, headers: headerOptions});
    // return this.http.post('http://localhost:51845/api/Employees', body, requestOptions).pipe(map(x => x.json()));
    return this.http.post('http://localhost:51845/api/Employees', employee);
  }

  getEmployee() {
    // this.http.get('http://localhost:51845/api/Employees')
    // .pipe(map((data: Response) => {
    //     return data.json() as Employee[];
    //   })).toPromise().then(x => {
    //     this.employeelist = x; }
    //   );

      this.http.get('http://localhost:51845/api/Employees')
      .subscribe((x: Employee[]) =>
          this.employeelist = x );
  }

  putEmployee(id, emp) {
    // const body = JSON.stringify(emp);
    // const headerOptions = new Headers({'Content-Type': 'application/json'});
    // const requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headerOptions});
    // return this.http.put('http://localhost:51845/api/Employees/' + id, body, requestOptions).pipe(map(x => x.json()));
    return this.http.put('http://localhost:51845/api/Employees/' + id, emp);
  }

  deleteEmployee(id) {
    // return this.http.delete('http://localhost:51845/api/Employees/' + id).pipe(map(x => x.json()));
    return this.http.delete('http://localhost:51845/api/Employees/' + id);
  }
}

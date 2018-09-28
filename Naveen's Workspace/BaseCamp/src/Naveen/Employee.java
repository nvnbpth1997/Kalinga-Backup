package Naveen;
import java.util.InputMismatchException;
import java.util.Scanner;
public class Employee {
	int empID;
	String empName; 
	String empDesig;
	String empDept; 
		
	public Employee()
	{
		empID = 0;
		empName = null;
		empDesig = null;
		empDept = null;
	}

	public int getEmpID() {
		return empID;
	}
	public String getEmpName() {
		return empName;
		
	}
	 public String getEmpDesig() {
		 return empDesig;
		 
	 }
	public String getEmpDept() {
		return empDept;
		
	}
	public void setEmpID(int empNo) {
		
		empID = empNo;
	}
	
	public void setEmpName(String empName) {
		try {
			if(empName==null)
				throw new NullPointerException();
			else 
				this.empName = empName;
		}
		catch(NullPointerException e) {
			System.out.println("Employee name cannot be NULL");
		}
		catch(InputMismatchException e)
		{
			System.out.println("Employee name cannot be a Non-Alphabet");
		}
		
	}
	
	public void setEmpDesig(String empDesig) {
		try {
		if(!empDesig.equals("developer")&&!empDesig.equals("tester")&&!empDesig.equals("Lead")&&!empDesig.equals("manager"))
			throw new Exception("Invalid Designation");
		else
			this.empDesig = empDesig;
		}
		catch(Exception e) {
			System.out.println(e.toString());
		}
	 }
	
	 public void setEmpDept(String esmpDept) {
		 try {
		 if(!esmpDept.equals("C2")&&!esmpDept.equals("TTG")&&!esmpDept.equals(" ITES")&&!esmpDept.equals(" PES"))
		    throw new Exception("Invalid Dept");
		 else
			 empDept = esmpDept;
		 }
		 catch(Exception e) {
			 System.out.println(e.toString());
		 }
	 }
	 	
	 	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scan = new Scanner(System.in);
				Employee emp = new Employee();
				
				try {
					emp.setEmpID(scan.nextInt());
				}catch(InputMismatchException e)
				{
					System.out.println("ID cannot be non-Integer!");
				}
				
				emp.setEmpName(scan.next());
				emp.setEmpDesig(scan.next());
				emp.setEmpDept(scan.next());
				
				System.out.println("Employee ID:"+emp.getEmpID());
				System.out.println("Employee Name:"+emp.getEmpName());
				System.out.println("Employee Designation:"+emp.getEmpDesig());
				System.out.println("Employee Department:"+emp.getEmpDept());
				
				scan.close();
			}

}

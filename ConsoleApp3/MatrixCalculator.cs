using System;

namespace ConsoleApp3 {
  public class MatrixCalculator { 
    private MatrixCalculator() {
    }
    private static MatrixCalculator Instance;
   
    public static MatrixCalculator GetInstance { 
      get {
        
        if (Instance == null) { 
          Instance = new MatrixCalculator();        
        }

        return Instance;
      }
    }

    private MatrixClone CreateMatrix() { 
      var NotSet = true;
      Console.WriteLine("Enter matrix name: ");
      var Name = Console.ReadLine();
      Console.WriteLine("\nGenerate matrix?\n");
      Console.WriteLine("No        0");
      Console.WriteLine("Yes       1");

      while (NotSet) {

        switch (Console.ReadLine()) {
          case "0":
            NotSet = false;
            break;

          case "1":
            return new MatrixClone(Name);

          default:
            Console.WriteLine("Error.");
            break;
        }
      }
      NotSet = true;
      var Size = 0;

      while (NotSet) { 
        Console.WriteLine("\nEnter matrix size: ");

        if (!int.TryParse(Console.ReadLine(), out Size)) {
          Console.WriteLine("Error.");        
        } else { 
          NotSet = false;      
        }
      }

      NotSet = true;
      Console.WriteLine("\nGenerate elements?\n");
      Console.WriteLine("No        0");
      Console.WriteLine("Yes       1");

      while (NotSet) {

        switch (Console.ReadLine()) {
          case "0":
            NotSet = false;
            break;

          case "1":
            return new MatrixClone(Name, Size);

          default:
            Console.WriteLine("Error.");
            break;
        }
      }

      NotSet = true;
      var Elements = new double[Size, Size];
      double ThisElemenets;
      
      for (var LineIndex = 0; LineIndex < Size; LineIndex++) {
       
        for (var ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++) {
          
          while (NotSet) { 
            Console.WriteLine($"Enter elements {LineIndex}{ColumnIndex}: ");
                    
            if (!double.TryParse(Console.ReadLine(), out ThisElemenets)) {
              Console.WriteLine("Error.");
            } else { 
              Elements[LineIndex, ColumnIndex] = ThisElemenets;
              NotSet = false;
            }
          }
          NotSet = true;
        }
      }

      return new MatrixClone(Name, Size, Elements);
    }

    private void GetInfo(MatrixClone Matrix) { 
      Console.WriteLine($"Matrix {Matrix.NameMatrix}");    
      Console.WriteLine($"Determinant {Matrix.Determinant()}");    
      Console.WriteLine($"Hash code {Matrix.GetHashCode()}");    
      Console.WriteLine($"Sum of elements {Matrix.Sum()}");    
      Console.WriteLine($"As string {Matrix}");    
    }

    private string Comparison(MatrixClone left, MatrixClone right) {
      
      if (left > right) {
        return $"{left.NameMatrix} > {right.NameMatrix}";      
      } else if (left < right) { 
        return $"{left.NameMatrix} < {right.NameMatrix}";   
      } else { 
        return $"{left.NameMatrix} = {right.NameMatrix}";         
      }
    }

    public void Calculator() { 
      Console.WriteLine("Create first matrix:\n");
      var left = CreateMatrix();
      Console.Clear();

      Console.WriteLine("Create second matrix:\n");
      var right = CreateMatrix();
      Console.Clear();

      left.Print();
      Console.WriteLine("\n");

      right.Print();
      Console.WriteLine("\n");

      Console.WriteLine("Info         0");
      Console.WriteLine("Transpose    1");
      Console.WriteLine("Compare      2");
      Console.WriteLine("Add up       3");
      Console.WriteLine("Subtract     4");
      Console.WriteLine("Multiply     5");
      Console.WriteLine("Exit         6");

      var Option = true;

      while (true) {

        while (Option) {
          Console.WriteLine("\nChoose option");

          switch (Console.ReadLine()) { 

            case "0":
              Console.WriteLine("\n");
              GetInfo(left);
              Console.WriteLine("\n");
              GetInfo(right);
              Option = false;
              break;

            case "1":
              var TransposeMatrix = (SquareMatrix)left.Clone();
              TransposeMatrix = TransposeMatrix.Transpose();
              TransposeMatrix.Print();
              Option = false;
              break;

            case "2":
              Console.WriteLine(Comparison(left, right));
              Option = false;
              break;

            case "3":
              try { 
                var Result = (SquareMatrix)left.Clone();
                Result += right;
                Result.Print();
              }
              catch (MatrixExcepton Exception){
                Console.WriteLine(Exception.Message);
                break;
              }
              Option = false;
              break;

            case "4":
              try { 
                var Result = (SquareMatrix)left.Clone();
                Result -= right;
                Result.Print();
              }
              catch (MatrixExcepton Exception){
                Console.WriteLine(Exception.Message);
                break;
              }
              Option = false;
              break;

            case "5":
              try { 
                var Result = (SquareMatrix)left.Clone();
                Result *= right;
                Result.Print();
              }
              catch (MatrixExcepton Exception){
                Console.WriteLine(Exception.Message);
                break;
              }
              Option = false;
              break;

            case "6":
              return;

            default:
              Console.WriteLine("Error.");
              break;
          }
          Option = true;
        }     
      }
    }
  }
}
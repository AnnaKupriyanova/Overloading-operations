using System;

namespace ConsoleApp3 {
  public class SquareMatrix : IComparable {
    public string NameMatrix { get; set; }
    public int SizeMatrix { get; set; }
    public double[,] Matrix { get; set; }
    public SquareMatrix() {
    }

    public SquareMatrix(string Name) {
      Random rand = new Random();
      NameMatrix = Name;
      SizeMatrix = rand.Next(2, 4);
      Matrix = new double[SizeMatrix, SizeMatrix];

      for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) {
          Matrix[LineIndex, ColumnIndex] = rand.Next(-100, 100);    
        }

      }
    }

    public SquareMatrix(string Name, int Size) {
      Random rand = new Random();
      NameMatrix = Name;
      SizeMatrix = Size;
      Matrix = new double[SizeMatrix, SizeMatrix];

      for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) {
          Matrix[LineIndex, ColumnIndex] = rand.Next(-100, 100);    
        }

      }
    }

    public SquareMatrix(string Name, int Size, double[,] Elements) {
      Random rand = new Random();
      NameMatrix = Name;
      SizeMatrix = Size;
      Matrix = new double[SizeMatrix, SizeMatrix];

      for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) {
          Matrix[LineIndex, ColumnIndex] = Elements[LineIndex, ColumnIndex];    
        }

      }
    }

    public double Sum() { 
      double SumElements = 0;

      for (var LineIndex = 0;LineIndex < SizeMatrix; ++LineIndex) { 

        for (var ColumnIndex = 0;ColumnIndex < SizeMatrix; ++ColumnIndex) { 
          SumElements += Matrix[LineIndex, ColumnIndex];       
        }      

      }

      return SumElements;
    }

    public double Determinant() { 
      double DeterminantMatrix = 0;

      if (this.SizeMatrix == 2) { 
        DeterminantMatrix = (this.Matrix[0, 0] * this.Matrix[1, 1] - this.Matrix[1, 0] * this.Matrix[0, 1]);      
      } else {
        DeterminantMatrix = (this.Matrix[0, 0] * this.Matrix[1, 1] * this.Matrix[2, 2] + this.Matrix[0, 1] * this.Matrix[1, 2] * this.Matrix[2, 0] + this.Matrix[1, 0] * this.Matrix[2, 1] * this.Matrix[0, 2] - this.Matrix[2, 0] * this.Matrix[1, 1] * this.Matrix[0, 2] - this.Matrix[1, 0] * this.Matrix[0, 1] * this.Matrix[2, 2] - this.Matrix[2, 1] * this.Matrix[1, 2] * this.Matrix[0, 0]);      
      }

      return DeterminantMatrix;
    }

    public SquareMatrix Transpose() {
      var TransposeMatrix = new SquareMatrix($"{this.NameMatrix} transposed", this.SizeMatrix);

      for (var LineIndex = 0; LineIndex < this.SizeMatrix; ++LineIndex) { 

        for (var ColumnIndex = 0; ColumnIndex < this.SizeMatrix; ++ColumnIndex) {
          TransposeMatrix.Matrix[ColumnIndex, LineIndex] = this.Matrix[LineIndex, ColumnIndex];
        }

      }

      return TransposeMatrix;
    }

    public static SquareMatrix operator + (SquareMatrix left, SquareMatrix right) {

      if (left.SizeMatrix != right.SizeMatrix) {
        throw new MatrixExcepton("The option isn`t possible.");
      }

      double [,] Elements = new double [left.SizeMatrix, left.SizeMatrix];

      for (var LineIndex = 0; LineIndex < left.SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < left.SizeMatrix; ++ColumnIndex) {
          Elements[LineIndex, ColumnIndex] = left.Matrix[LineIndex, ColumnIndex] + right.Matrix[LineIndex, ColumnIndex];
        }

      }

      var Name = "Result";

      return new SquareMatrix(Name, left.SizeMatrix, Elements);
    }

    public static SquareMatrix operator - (SquareMatrix left, SquareMatrix right) {

      if (left.SizeMatrix != right.SizeMatrix) {
        throw new MatrixExcepton("The option isn`t possible.");
      }

      double [,] Elements = new double [left.SizeMatrix, left.SizeMatrix];

      for (var LineIndex = 0; LineIndex < left.SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < left.SizeMatrix; ++ColumnIndex) {
          Elements[LineIndex, ColumnIndex] = left.Matrix[LineIndex, ColumnIndex] - right.Matrix[LineIndex, ColumnIndex];
        }

      }

      var Name = "Result";

      return new SquareMatrix(Name, left.SizeMatrix, Elements);
    }

    public static SquareMatrix operator * (SquareMatrix left, SquareMatrix right) {

      if (left.SizeMatrix != right.SizeMatrix) {
        throw new MatrixExcepton("The option isn`t possible.");
      }

      double [,] Elements = new double [left.SizeMatrix, left.SizeMatrix];

      for (var LineIndex = 0; LineIndex < left.SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < left.SizeMatrix; ++ColumnIndex) {
          Elements[LineIndex, ColumnIndex] = left.Matrix[LineIndex, ColumnIndex] * right.Matrix[LineIndex, ColumnIndex];
        }

      }

      var Name = "Result";

      return new SquareMatrix(Name, left.SizeMatrix, Elements);
    }

    public static bool operator < (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() < right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator > (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() > right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator <= (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() <= right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator >= (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() >= right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator == (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() == right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator != (SquareMatrix left, SquareMatrix right) { 

      if (left.Sum() != right.Sum()) { 
        return true;      
      }    

      return false;
    }

    public static bool operator true (SquareMatrix Matrix) {
      return (Matrix.Determinant() != 0);    
    }

    public static bool operator false (SquareMatrix Matrix) {
      return (Matrix.Determinant() == 0);
    }

    public static implicit operator string (SquareMatrix Matrix) {
      var Result = "";

      for (var LineIndex = 0; LineIndex < Matrix.SizeMatrix; LineIndex++) {
        
        for (var ColumnIndex = 0;ColumnIndex < Matrix.SizeMatrix; ColumnIndex++) {
          Result += $"{Matrix.Matrix[LineIndex,ColumnIndex]} ";
        }

      }

      return Result;
    }

    public static implicit operator SquareMatrix (double[,] Elements) { 
      var AmountElements = Elements.Length;
            
      if (AmountElements % 2 == 0) {
        var Size = AmountElements / 2;
        return new SquareMatrix ("Result", Size, Elements);
      } else { 
        throw new MatrixExcepton("Array sizes of different lengths");      
      }
    }

    public override string ToString() {
      var Result = "";

      for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) {

        for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) {
          Result += ($"{Matrix[LineIndex, ColumnIndex]} ");
        }

      }

      return Result;
    }

    int IComparable.CompareTo(object other) {

      if (other is SquareMatrix) {
        var param = other as SquareMatrix;

        if (param.Sum() > this.Sum()) return -1;
        if (param.Sum() < this.Sum()) return 1;
        if (param.Sum() == this.Sum()) return 0;

      }

      return -1;
    }

    public override bool Equals(object other) {
      bool Result = false;

      if (other is SquareMatrix) {
        var param = other as SquareMatrix;

        if ((param.SizeMatrix == this.SizeMatrix)) { 
          Result = true;        
        }

        for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) { 
          for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) { 
            if (param.Matrix[LineIndex, ColumnIndex] == this.Matrix[LineIndex,ColumnIndex]) { 
              Result = true;   
            }
          }
        }
      }

      return Result;
    }

    public override int GetHashCode() {
      return (int)this.Sum();    
    }

    public void Print() { 
      var Row = "";
      Console.WriteLine($"Matrix {this.NameMatrix}:\n");

      for (var LineIndex = 0; LineIndex < SizeMatrix; ++LineIndex) { 

        for (var ColumnIndex = 0; ColumnIndex < SizeMatrix; ++ColumnIndex) { 
          Row += $"{this.Matrix[LineIndex, ColumnIndex]} "; 
        }

        Console.WriteLine(Row);
        Console.WriteLine();
        Row = "";
      }
    }
  }
}
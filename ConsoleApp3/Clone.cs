using System;

namespace ConsoleApp3 {
  public class MatrixClone : SquareMatrix, ICloneable { 
    public MatrixClone() {
    }

    public MatrixClone(string Name) : base(Name) {
    }

    public MatrixClone(string Name, int Size) : base(Name, Size) {
    }

    public MatrixClone(string Name, int Size, double[,] Elements) : base(Name, Size, Elements) {
    }

    public object Clone() {
      var Clone = new MatrixClone();
      Clone.NameMatrix = this.NameMatrix;
      Clone.SizeMatrix = this.SizeMatrix;
      Clone.Matrix = this.Matrix;
      return Clone;
    }
  }
}
using System;

namespace ConsoleApp3 {
  public class MatrixExcepton : Exception { 
    public MatrixExcepton (string message) : base(message) {
    }
  }
}
// Exercise 9.1 (i)

/*
public static void SelectionSort(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        int least = i;
        for (int j = i + 1; j < arr.Length; j++)
            if (arr[j] < arr[least])
                least = j;
        int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;
    }
}
*/

  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4                  // The int32 specifies the maximum number of elements on the evaluation stack during the execution of the method.
    .locals init (                // The following declares 4 local variables, each of which is to be initialized to its default value.
             int32 V_0,           // V_0 = i
             int32 V_1,           // V_1 = least
             int32 V_2,           // V_2 = j
             int32 V_3)           // V_3 = tmp
    IL_0000:  ldc.i4.0            // Push constant 0 onto the stack as int32
    IL_0001:  stloc.0             // Pop a value from stack into loca variable 0
    IL_0002:  br.s       IL_0032  // Branch (jump to) to instruction IL_0032

    IL_0004:  ldloc.0             // Load local variable 0 (i) onto stack
    IL_0005:  stloc.1             // Pop a value from stack into local variable 1 (least) 
    IL_0006:  ldloc.0             // Load local variable 0 (i) onto stack
    IL_0007:  ldc.i4.1            // Push 1 onto the stack as int32
    IL_0008:  add                 // Add two values, returning a new value. least = i
    IL_0009:  stloc.3             // Pop a value from stack into local variable 3 (tmp) 
    IL_000a:  br.s       IL_001a  // Branch (jump to) to instruction IL_001a

    IL_000c:  ldarg.0             // Load argument 0 (arr) onto stack 
    IL_000d:  ldloc.3             // Load local variable 3 (tmp) onto stack
    IL_000e:  ldelem.i4           // Load the element of array with type int32 at index onto the top of the stack as an int32.

    IL_000f:  ldarg.0             // Load argument 0 (arr) onto stack   
    IL_0010:  ldloc.1             // Load local variable 1 (least) onto stack
    IL_0011:  ldelem.i4           // Load the element of array with type int32 at index onto the top of the stack as an int32.
    IL_0012:  bge.s      IL_0016  // Branch (jump to) to target instruction IL_0016 if greater than or equal to, short form.

    IL_0014:  ldloc.3             // Load local variable 3 (tmp) onto stack
    IL_0015:  stloc.1             // Pop a value from stack into local variable 1 (least)
    IL_0016:  ldloc.3             // Load local variable 3 (tmp) onto stack
    IL_0017:  ldc.i4.1            // push 1 onto the stack as int32
    IL_0018:  add                 // Add two values, returning a new value
    IL_0019:  stloc.3             // Pop a value from stack into local variable 3 (tmp) 
    IL_001a:  ldloc.3             // Load local variable 3 (tmp) onto stack
    IL_001b:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_001c:  ldlen               // Push the length (of type native unsigned int) of array on the stack
    IL_001d:  conv.i4             // Convert the value at the top of the stack to int32 and pushing it to the stack
    IL_001e:  blt.s      IL_000c  // Branch (jump to) to target instruction IL000c if less than, short form.

    IL_0020:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_0021:  ldloc.0             // Load local variable 0 (i) onto stack
    IL_0022:  ldelem.i4           // Load the element of array with type int32 at index onto the top of the stack as an int32.
    IL_0023:  stloc.2             // Pop a value from stack into local variable 2 (j)
    IL_0024:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_0025:  ldloc.0             // Load local variable 0 onto stack
    IL_0026:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_0027:  ldloc.1             // Load local variable 1 (least) onto stack
    IL_0028:  ldelem.i4           // Load the element of array with type int32 at index onto the top of the stack as an int32
    IL_0029:  stelem.i4           // Replace array element at index with the int32 value on the stack
    IL_002a:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_002b:  ldloc.1             // Load local variable 1 (least) onto stack
    IL_002c:  ldloc.2             // Load local variable 2 (j) onto stack
    IL_002d:  stelem.i4           // Replace array element at index with the int32 value on the stack
    IL_002e:  ldloc.0             // Load local variable 0 (i) onto stack
    IL_002f:  ldc.i4.1            // Push 1 onto the stack as int32
    IL_0030:  add                 // Add two values, returning a new value
    IL_0031:  stloc.0             // Pop a value from stack into local variable 0 (i) 
    IL_0032:  ldloc.0             // Load local variable 0 (i) onto stack
    IL_0033:  ldarg.0             // Load argument 0 (arr) onto the stack
    IL_0034:  ldlen               // Push the length (of type native unsigned int) of array on the stack
    IL_0035:  conv.i4             // Convert the value at the top of the stack to int32 and pushing it to the stack
    IL_0036:  blt.s      IL_0004  // Branch (jump to) to target instruction IL_0004 if less than, short form.

    IL_0038:  ret                 // Return from method
  } // end of method Selsort::SelectionSort
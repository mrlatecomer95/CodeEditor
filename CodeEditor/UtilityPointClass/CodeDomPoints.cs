using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UtilityPointClass
{
    public static class CodeDomPoints
    {

        public static void createType(string name, IList<PointClass> props)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            //var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Test.Dynamic.dll", false); //Original
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Dynamic.Points.dll", false);
          
            parameters.GenerateExecutable = false;

            var compileUnit = new CodeCompileUnit();
            var ns = new CodeNamespace("Points");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));


            var classType = new CodeTypeDeclaration(name);
            classType.Attributes = MemberAttributes.Public;
            ns.Types.Add(classType);
            
            

            foreach (var prop in props)
            {
                var fieldName = "_" + prop.Name;
                var dataType = prop.DType;
                var field = new CodeMemberField(dataType, fieldName);
                field.Type = new CodeTypeReference(dataType);
                //field.InitExpression = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(prop.DType), fieldName);
                var initValue = Convert.ChangeType(prop.Value, dataType);
                field.InitExpression = new CodePrimitiveExpression(initValue);
                classType.Members.Add(field);

                var property = new CodeMemberProperty();
                property.Attributes = classType.Attributes = MemberAttributes.Public;
              
                
                property.Name = prop.Name;
                property.Type = new CodeTypeReference(dataType);

                CodeMemberMethod fieldn = new CodeMemberMethod();

                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                //property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));

                classType.Members.Add(property);
                
            }

            var results = csc.CompileAssemblyFromDom(parameters, compileUnit);
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));

            /* For Testing */
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter("C:\\Users\\earlsan.villegas\\Desktop\\Test\\test.txt"))
            {
                csc.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options);
            }
            /* End Testing */

        }



    }
}

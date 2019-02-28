using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vanguard
{
   
        

       /// <summary>
       ///错误信息
       /// </summary>
       public struct s_CheckError
       {
           public int iErrortype;
           public string strErrorInfo;
       }

       public  class zxd
       {
       #region  //文件操作
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern string GetDirctoryEx();
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern bool FolderExistEx(string strPath);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern bool DiskExistEx(string stDiskName);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern void CreateAllDirectoryEx(string szPath);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern string GetCurrentTimeAsStringEx();
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern bool FileExistEx(string FileName);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern bool DeleteDirectoryEx(string DirName);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern void LogEx(string szPath, string szText, bool bWriteFileLine, string szFileLineText);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern double RadEx(double dAngele);
       //
       [DllImport("ZazaniaoHalconDll.dll")]
       public static extern double DegEx(double dAngele);
       #endregion

       #region //INI文件读写
       [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
       public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);

       [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
       public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

       //再一种声明，使用string作为缓冲区的类型同char[]
       [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
       public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, uint nSize, string lpFileName);

       /// <summary>
       /// 将指定的键和值写到指定的节点，如果已经存在则替换
       /// </summary>
       /// <param name="lpAppName">节点名称</param>
       /// <param name="lpKeyName">键名称。如果为null，则删除指定的节点及其所有的项目</param>
       /// <param name="lpString">值内容。如果为null，则删除指定节点中指定的键。</param>
       /// <param name="lpFileName">INI文件</param>
       /// <returns>操作是否成功</returns>
       [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
       [return: MarshalAs(UnmanagedType.Bool)]
       public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

       #endregion

       internal static void LogEx(string p1, ushort[] nums, bool p2, string p3)
       {
           throw new NotImplementedException();
       }
       }
      
       public class Param
       {
           public int ResultOk;
           public int ResultSum;
           public string RobotIp;
           public string RobotPort;
           public string VanguardIP;
           public string VanguardPort;
           
           public Param()
           {
               ResultOk = 0;
               ResultSum = 0;
               RobotIp = "192.168.0.123";
               RobotPort = "110";
               VanguardIP = "192.168.0.1";
               VanguardPort = "502";
               

           }

       }


       public class Vision
       {
           #region //单例
           private static Vision _instance = null;
           public static Vision Instance()
           {
               if (_instance == null)
               {
                   _instance = new Vision();
               }
               return _instance;
           }
           #endregion
           #region //定义变量
           public Param param = new Param();
           #endregion
           #region //GetPrivateProfileDouble 获取局部的double参数
           public double GetPrivateProfileDouble(string lpAppName, string lpKeyName, double Default, string lpFileName)
           {
               // char[] lpReturnedString = new char[1024];
               StringBuilder lpReturnedString = new StringBuilder(1024);
               zxd.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);
               return Convert.ToDouble(lpReturnedString.ToString());


           }
           #endregion

           #region //GetPrivateProfileInt  获取局部的int参数
           public int GetPrivateProfileInt(string lpAppName, string lpKeyName, int Default, string lpFileName)
           {
               //char[] lpReturnedString = new char[1024];
               StringBuilder lpReturnedString = new StringBuilder(1024);
               zxd.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);

               return Convert.ToInt32(lpReturnedString.ToString());
           }
           #endregion

           #region //GetPrivateProfileString  获取局部的string参数
           public string GetPrivateProfileString(string lpAppName, string lpKeyName, string Default, string lpFileName)
           {
               StringBuilder lpReturnedString = new StringBuilder(1024);
               zxd.GetPrivateProfileString(lpAppName, lpKeyName, Default, lpReturnedString, 1024, lpFileName);
               return lpReturnedString.ToString();
           }
           #endregion

           #region //保存参数
           public s_CheckError SaveConfigFile()
           {
               s_CheckError Error;
               Error.iErrortype = 0;
               Error.strErrorInfo = "";
               try
               {
                
                string INIStr;
                
                if (param.ResultSum == -1)
                {
                     Error.iErrortype = -1;
                    Error.strErrorInfo = "数据错误!";
                    return Error;
                }
                   //ini路径
                INIStr = Application.StartupPath + "\\DataResult\\" + "\\param.ini";
                CreateDirectoryEx(INIStr);
                   //参数变量
                zxd.WritePrivateProfileString("Result", "resultOK", Convert.ToString(param.ResultOk), INIStr);
                zxd.WritePrivateProfileString("Result", "resultSum", Convert.ToString(param.ResultSum), INIStr);
                Error.iErrortype = 0;
                Error.strErrorInfo = "保存参数成功!";
                return Error;
               }
               catch (Exception ex)
               {

                   Error.iErrortype = -1;
                   Error.strErrorInfo = "保存参数过程失败!";
                   Log(ex.Message);
                   return Error;
               }
           }

           #endregion

           #region //读取参数
           public s_CheckError loadconfigfile()
           {
               s_CheckError Error;
               try
               {
                   if (param.ResultSum == -1)
                   {
                       Error.iErrortype = -1;
                       Error.strErrorInfo = "数据错误!";
                       return Error;
                   }
                   string INIStr;
                   INIStr = Application.StartupPath + "\\DataResult\\" + "\\param.ini";
                   param.ResultOk = GetPrivateProfileInt("Result", "resultOK", 0, INIStr);
                   param.ResultSum = GetPrivateProfileInt("Result", "resultSum", 0, INIStr);
                   param.RobotIp = GetPrivateProfileString("Result", "RobotIp", "0", INIStr);
                   param.RobotPort = GetPrivateProfileString("Result", "RobotPort", "0", INIStr);
                   param.VanguardIP = GetPrivateProfileString("Result", "VanguardIP", "0", INIStr);
                   param.VanguardPort = GetPrivateProfileString("Result", "VanguardPort", "0", INIStr);



                   Error.iErrortype = 0;
                   Error.strErrorInfo = "读取参数成功!";
                   return Error;
               }
               catch (Exception ex)
               {

                   Error.iErrortype = -1;
                   Error.strErrorInfo = "读取参数过程失败!";
                   Log(ex.Message);
                   return Error;
               }
           }
           #endregion

           #region Log
           public void Log(string str)
           {
               zxd.LogEx(Application.StartupPath + "\\Log\\ErrorLog.csv", str, true, "描述");
           }
           #endregion

           #region //CreateDirectoryEx  Path必须为完整路径+文件名，如：c://aa//1.bmp，会自动创建完整路径
           public void CreateDirectoryEx(string Path)
           {
               int nPos;
               string PathTemp;
               nPos = Path.LastIndexOf('\\');
               if (nPos < 0)
                   nPos = Path.LastIndexOf('/');
               if (nPos < 0)
                   return;
               if (nPos > -1)
               {
                   PathTemp = Path.Substring(0, nPos);
               }
               else
               {
                   nPos = Path.LastIndexOf('/');
                   PathTemp = Path.Substring(0, nPos);
               }

               Directory.CreateDirectory(PathTemp);
           }
           #endregion

           

           #region //GetCurrentTimeAsStringEx
           public string GetCurrentTimeAsStringEx()
           {
               return string.Format("0", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff"));
           }
           #endregion
       }
      
    }


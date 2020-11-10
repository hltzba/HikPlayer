using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace HikPlayer.HickPlayerSDK
{
    public class HikPlayer
    {
        #region 解码库
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern uint PlayM4_GetLastError(int nPort);
        /// <summary>
        /// 获取文件当前播放位置（百分比）。
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern float PlayM4_GetPlayPos(int nPort);
        /// <summary>
        ///设置文件当前播放位置（百分比）。
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern float PlayM4_SetPlayPos(int nPort, float fRelativePos);
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern uint PlayM4_GetFileHeadLength();
        /// <summary>
        /// 获取文件总时间
        /// </summary>
        /// <param name="nPort"></param>PlayM4_GetPlayedTime
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern uint PlayM4_GetFileTime(int nPort);
        /// <summary>
        /// 获取当前播放时间
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern uint PlayM4_GetPlayedTime(int nPort);
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern int PlayM4_GetCaps();
        /// <summary>
        /// 关闭声音
        /// </summary>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_StopSound();
        /// <summary>
        /// 获取未使用的通道号
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_GetPort(ref int nPort);
        /// <summary>
        ///播放声音
        /// </summary>
        /// <param name="nPort"></param>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_PlaySound(int nPort);
        /// <summary>
        /// 设置流播放模式
        /// </summary>
        /// <param name="port"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_SetStreamOpenMode(int nPort, int mode);
        /// <summary>
        /// 打开流
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="pFileHeadBuf"></param>
        /// <param name="nSize"></param>
        /// <param name="nBufPoolSize"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, UInt32 nSize, uint nBufPoolSize);
        /// <summary>
        /// 设置播放缓冲区最大缓冲帧数
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="nNum"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_SetDisplayBuf(int nPort, uint nBufPoolSize);
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_OpenFile(int nPort, string fileName);
        /// <summary>
        /// 关闭文件
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_CloseFile(int nPort);
        /// <summary>
        /// 开启播放
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);
        /// <summary>
        /// 开始倒放
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_ReversePlay(int nPort);
        /// <summary>
        /// 输入流数据
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="pBuf"></param>
        /// <param name="nSize"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_InputData(int nPort, byte[] pBuf, uint nSize);
        /// <summary>
        /// 关闭播放
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>PlayM4_Pause
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_Stop(int nPort);
        /// <summary>
        ///暂停/播放1：暂停，0：恢复
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_Pause(int nPort, uint nPause);
        /// <summary>
        /// 关闭流
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_CloseStream(int nPort);
        /// <summary>
        /// 释放已使用的通道号
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [SecurityCritical]
        [DllImport("HickPlayerSDK\\PlayCtrl.dll")]
        public static extern bool PlayM4_FreePort(int nPort);

        #endregion
    }
}

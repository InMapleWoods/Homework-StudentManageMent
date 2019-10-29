using Dal;
using Model;
using System;
using System.Collections;
using System.Data;

namespace Bll
{
    /// <summary>
    /// 考试用户层
    /// </summary>
    public class ExaminationBll
    {
        /// <summary>
        /// 考试数据操作对象
        /// </summary>
        private readonly ExaminationDal examinationDal = new ExaminationDal();

        #region 考试相关
        /// <summary>
        /// 获取分页后的考试列表
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperExam(int index, int size)
        {
            DataTable datatable = null;
            try
            {
                datatable = examinationDal.GetPaperExam(index, size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return datatable;
        }
        /// <summary>
        /// 获取分页后的考试数组
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单数组</returns>
        public IEnumerable GetPageExamArray(int index, int size)
        {
            ArrayList examinations = new ArrayList();
            try
            {
                DataTable datatable = examinationDal.GetPaperExam(index, size);
                foreach (DataRow dr in datatable.Rows)
                {
                    Examination examination = new Examination((int)dr["Id"], (int)dr["CourseId"], (DateTime)dr["Time"], dr["Name"].ToString());
                    examinations.Add(examination);
                }
                return examinations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
        }

        /// <summary>
        /// 获取分页后的考试列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageNum(int size)
        {
            int result = 0;
            try
            {
                result = examinationDal.GetAllPageNum(size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 获取全部考试
        /// </summary>
        /// <returns>返回考试列表</returns>
        public DataTable GetAllExamination()
        {
            DataTable result = null;
            try
            {
                result = examinationDal.GetAllExamination();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;

        }

        /// <summary>
        /// 按Id获取考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>符合条件的考试</returns>
        public Examination GetExaminationById(int id)
        {
            Examination result = null;
            try
            {
                result = examinationDal.GetExaminationById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 按考试Id获取考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>符合条件的所有考试</returns>
        public DataTable GetExaminationByCourseId(int id)
        {
            DataTable result = null;
            try
            {
                result = examinationDal.GetExaminationByCourseId(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 增加考试
        /// </summary>
        /// <param name="examination">考试</param>
        /// <returns>增加成功与否</returns>
        public bool AddExamination(Examination examination)
        {
            bool result = false;
            try
            {
                result = examinationDal.AddExamination(examination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 删除考试
        /// </summary>
        /// <param name="id">考试Id</param>
        /// <returns>删除成功与否</returns>
        public bool DeleteExamination(int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.DeleteExamination(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 修改考试时间
        /// </summary>
        /// <param name="dateTime">考试时间</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        public bool UpdateExaminationTime(DateTime dateTime, int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.UpdateExaminationTime(dateTime, id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 修改考试名称
        /// </summary>
        /// <param name="name">考试名称</param>
        /// <param name="id">需要修改的考试id</param>
        /// <returns>修改成功与否</returns>
        public bool UpdateExaminationName(string name, int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.UpdateExaminationName(name, id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }
        #endregion

        #region 考试申请相关
        /// <summary>
        /// 获取分页后的考试申请列表
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单</returns>
        public DataTable GetPaperExamApply(int index, int size)
        {
            DataTable result = null;
            try
            {
                result = examinationDal.GetPaperExamApply(index, size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }
        /// <summary>
        /// 获取分页后的考试申请数组
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="size">分页大小</param>
        /// <returns>分页后名单数组</returns>
        public IEnumerable GetPageExamApplyArray(int index, int size)
        {
            ArrayList examApplyLogArray = new ArrayList();
            try
            {
                DataTable result = examinationDal.GetPaperExamApply(index, size);
                foreach (DataRow dr in result.Rows)
                {
                    examApplyLogArray.Add(new ExamApply((int)dr["Id"], (int)dr["TeacherId"], (int)dr["CourseId"], (DateTime)dr["Time"], dr["ExamName"].ToString(), (bool)dr["isChecked"]));
                }
                return examApplyLogArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
        }

        /// <summary>
        /// 获取分页后的考试申请列表总页数
        /// </summary>
        /// <param name="size">分页大小</param>
        /// <returns>分页数</returns>
        public int GetAllPageApplyNum(int size)
        {
            int result = 0;
            try
            {
                result = examinationDal.GetAllPageApplyNum(size);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;

        }

        /// <summary>
        /// 增加考试申请
        /// </summary>
        /// <param name="examination">考试</param>
        /// <param name="teacherId">教师Id</param>
        /// <returns>增加成功与否</returns>
        public bool AddExamApply(Examination examination, int teacherId)
        {
            bool result = false;
            try
            {
                result = examinationDal.AddExamApply(examination, teacherId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 改变考试申请状态
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>改变成功与否</returns>
        public bool UpdateExamApplyCheckedState(int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.UpdateExamApplyCheckedState(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;
        }

        /// <summary>
        /// 接受考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>接受成功与否</returns>
        public bool AccpetExamApply(int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.AccpetExamApply(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;

        }

        /// <summary>
        /// 拒绝考试申请
        /// </summary>
        /// <param name="id">考试申请Id</param>
        /// <returns>拒绝成功与否</returns>
        public bool RejectExamApply(int id)
        {
            bool result = false;
            try
            {
                result = examinationDal.RejectExamApply(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw e;
            }
            return result;

        }
        #endregion

        /// <summary>
        /// 考试申请类
        /// </summary>
        private class ExamApply
        {
            int Id { get; set; }
            int TeacherId { get; set; }
            int CourseId { get; set; }
            DateTime Time { get; set; }
            string ExamName { get; set; }
            bool IsChecked { get; set; }
            public ExamApply(int id, int teacherId, int courseId, DateTime time, string examName, bool isChecked)
            {
                Id = id;
                TeacherId = teacherId;
                CourseId = courseId;
                Time = time;
                ExamName = examName;
                IsChecked = isChecked;
            }
        }
    }
}

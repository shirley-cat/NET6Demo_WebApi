using System.Reflection;

namespace CommonCode.Converts
{
    public class ConvertTo
    {
        /// <summary>
        /// 实体类转换，要求两个类中的成员一致        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public static T ConvertModel<P,T>(in P pModel)
        {
            T ret = System.Activator.CreateInstance<T>();

            List<PropertyInfo> p_pis = pModel.GetType().GetProperties().ToList();
            PropertyInfo[] t_pis = typeof(T).GetProperties();

            foreach (PropertyInfo pi in t_pis)
            {
                //可写入数据
                if (pi.CanWrite)
                {
                    //忽略大小写
                    var name = p_pis.Find(s => s.Name.ToLower() == pi.Name.ToLower());
                    if (name != null && pi.PropertyType.Name == name.PropertyType.Name)
                    {
                        pi.SetValue(ret, name.GetValue(pModel, null), null);
                    }

                }
            }

            return ret;
        }
    }
}

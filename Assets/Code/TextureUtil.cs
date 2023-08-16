using UnityEngine;

namespace Code {
    public class TextureUtil {
        /// <summary>
        /// 取Texture3D的二维切片
        /// </summary>
        /// <param name="texture3D">Texture3D</param>
        /// <param name="dim">沿哪个维度取切片：0-x, 1-y, 2-z</param>
        /// <param name="idx">指定维度上的索引</param>
        /// <returns>texture3D在第dim维度上idx位置处的二维切片</returns>
        public static float[,] slice(Texture3D texture3D, int dim, int idx) {
            int dim1 = 0, dim2 = 0; // 返回数组的尺寸
            switch (dim) {
                case 0: {
                    dim1 = texture3D.height;
                    dim2 = texture3D.depth;
                    break;
                }
                case 1: {
                    dim1 = texture3D.width;
                    dim2 = texture3D.depth;
                    break;
                }
                case 2: {
                    dim1 = texture3D.width;
                    dim2 = texture3D.height;
                    break;
                }
            }

            float[,] array = new float[dim1, dim2];
            switch (dim) {
                case 0: {
                    for (int i = 0; i < dim1; i++) {
                        for (int j = 0; j < dim2; j++) {
                            array[i, j] = texture3D.GetPixel(idx, i, j).grayscale;
                        }
                    }

                    break;
                }
                case 1: {
                    for (int i = 0; i < dim1; i++) {
                        for (int j = 0; j < dim2; j++) {
                            array[i, j] = texture3D.GetPixel(i, idx, j).grayscale;
                        }
                    }

                    break;
                }
                case 2: {
                    for (int i = 0; i < dim1; i++) {
                        for (int j = 0; j < dim2; j++) {
                            array[i, j] = texture3D.GetPixel(i, j, idx).grayscale;
                        }
                    }

                    break;
                }
            }

            return array;
        }
    }
}
import numpy as np

matrixA = np.array([[34, 34], [34, 34], [34, 34], [34, 34]])
matrixB = np.array([[28, 28, 28, 28], [28, 28, 28, 28]])
vecrtorA = np.array([3, 5, 4])

print(np.dot(matrixA, matrixB))
print(np.dot(vecrtorA, matrixA))

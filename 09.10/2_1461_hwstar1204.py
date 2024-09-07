"""
n : 책의 개수
m : 한번에 들 수 있는 책 개수 
- 가까운거 먼저 
- 가장 먼거는 제일 나중에 옮기기
- 리스트 앞뒤로 m만큼 잘라서 앞뒤 두 리스트 중 더 큰값이 있는걸 거르기 
- 양수 음수 나눠서 해야하나? -> 나누지 않았을때 거리가 더 멀어짐 (책을 최대로 들고 한 방향으로 갔을때 다 두고오는 식으로 해야함)

[-39, -37, -29, -28, -6, 2, 11]
{(2,11), -6, (-28,-29) }* 2 + (-39,-37)
"""

n,m = map(int, input().split())
distances = list(map(int,input().split()))
minus, plus, total = [], [], []

for d in distances:
    plus.append(d) if d > 0 else minus.append(d)

# 음수
minus.sort()
for i in range(len(minus)//m):
    total.append(abs(minus[m*i]))

if len(minus) % m > 0:
    # 자리찾기 빡세네
    tmp = abs(minus[(len(minus)//m) * m])  
    total.append(tmp)

# 양수
plus.sort(reverse=True)
for j in range(len(plus)//m):
    total.append(plus[m*j])

if len(plus) % m > 0:
    tmp = plus[(len(plus)//m) * m]
    total.append(tmp)

print(sum(total)* 2 -max(total))

// 특정 길이까지의 소요 거리를 저장해두고 이를 재사용해야 함 => DP
// * 도착위치, 시작위치 순서를 기준으로 오름차순 정렬함
// * 0부터 D까지 10씩 증가하는 반복문
// * 지름길이 있는 도착 위치에서 '지름길 시작 위치까지의 거리 + 지름길 길이'가 제일 작은 값으로 갱신


let input = readLine()!.split(separator: " ").map { Int($0)! }
var n: Int = input[0], d: Int = input[1]

var shortcut: [[Int]] = []
for _ in 0..<n {
    let way = readLine()!.split(separator: " ").map { Int($0)! }
    shortcut.append(way)
}
shortcut.sort(by: { ($0[1], $0[0]) < ($1[1], $1[0]) })

var k: Int = 0
var isShort: Bool = true
var distance: [Int] = [0]

for i in 0..<d {
    var min: Int = distance[i]+1
    
    while isShort && shortcut[k][1] == i+1 {
        if min > distance[shortcut[k][0]] + shortcut[k][2] {
            min = distance[shortcut[k][0]] + shortcut[k][2]
        }
        if k < shortcut.count-1 { k += 1 }
        else { isShort = false }
    }
    
    distance.append(min)
}

print(distance.last!)

# 스파르타 던전 - UI 시스템 과제

Unity 기반 던전 게임에서 UI 시스템을 구현한 과제입니다.  
MainMenu, Status, Inventory UI를 직접 구성하고, 캐릭터 정보와 아이템 장착 효과까지 반영되도록 설계하였습니다.

---

## 구현 내용

| 구분        | 설명 |
|-------------|------|
| UI 구성     | UIMainMenu, UIStatus, UIInventory 3개 화면을 UGUI로 구성 |
| UI 전환     | 버튼 클릭 시 UI 간 전환 처리 (메인 <-> 상태창, 인벤토리) |
| 캐릭터 정보 | GameManager를 통해 초기 데이터 세팅 후, 각 UI에 표시 |
| 인벤토리    | 최소 9개 슬롯을 유지하며, 슬롯에 아이템 동적 할당 |
| 장착 기능   | 아이템 클릭 시 장착/해제 처리, E 마크로 표시 |
| 능력치 반영 | 장착된 아이템의 스탯이 캐릭터 상태창에 실시간 반영 |

---

## 주요 스크립트

```
Assets/
├── Scripts/
│   ├── GameManager.cs              // 캐릭터 초기 세팅 및 UI 연결
│   ├── Data/
│   │   ├── Character.cs            // 캐릭터 능력치 및 인벤토리 관리
│   │   └── ItemData.cs            // ScriptableObject 기반 아이템 정의
│   └── UI/
│       ├── UIManager.cs           // 싱글톤 기반 UI 접근
│       ├── UIMainMenu.cs          // 메인 메뉴 UI
│       ├── UIStatus.cs            // 능력치 상태창 UI
│       ├── UIInventory.cs         // 인벤토리 UI 및 슬롯 갱신
│       └── UISlot.cs              // 개별 슬롯 클릭 및 표시 관리
```

---

## 캐릭터 초기 데이터 예시

GameManager에서 인스펙터로 설정 가능:

- 이름: 홍진  
- 직업: 전사  
- 레벨: 5  
- 체력: 150  
- 공격력: 20  
- 방어력: 10  
- 크리티컬: 5  
- 소지금: 1000  
- 아이템: ScriptableObject로 구성된 장비 3종

---

## 데이터 구조

- `Character`: 인벤토리/장착 상태/능력치 포함
- `ItemData`: 아이템 정보 (이름, 설명, 아이콘, 스탯 등)
- `Inventory`: GameManager가 시작 시 캐릭터에 아이템 추가

---


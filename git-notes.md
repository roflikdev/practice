# Git notes

## Task 15 — Basic git

### Commands

```bash
git init -b main
git add .
git commit -m "feat: task 15 - init readme"
git switch -c feature/git-basics
git add README.md
git commit -m "feat: task 15 - edit feature"
git switch main
git merge feature/git-basics
# При конфликте: исправить README.md, убрать маркеры конфликта
git add README.md
git commit -m "feat: task 15 - resolve merge conflict"
git log --graph --oneline --all
```

### Output

Локальный учебный пример с настоящим конфликтом и его разрешением:

```text
Auto-merging README.md
CONFLICT (content): Merge conflict in README.md
Automatic merge failed; fix conflicts and then commit the result.

*   627fecb feat: task 15 - resolve merge conflict
|\
| * 91e875c feat: task 15 - edit feature
* | fa333c4 feat: task 15 - edit main
|/
* b864209 docs: task 15 - add notes
* dffeb1b feat: task 15 - init readme
```

В репозитории `practice` также есть учебная ветка `feature/git-basics`
и merge-коммит `29dcfb64` с двумя родителями:
`3e83c0bc` и `e13ea851`.
Это отдельная история коммитов, поэтому SHA в локальном примере другие.

### What I learned

Если две ветки меняют одну строку, Git не может выбрать вариант сам.
Нужно исправить файл и сохранить результат новым коммитом.

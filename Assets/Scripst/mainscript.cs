
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;



public class mainscript : MonoBehaviour

{
    public Animator Anim;
    // Start is called before the first frame update
    public UnityEngine.UI.Text gui_score; // очки текст
    public UnityEngine.UI.Text gui_game_over; // конец игры
    public UnityEngine.UI.Text gui_game_restart_reboot; // кнопка перезапуска
    public GameObject rebootbtn;
    public GameObject pref_block_pointer; 
    public int speedbooster_from_height = 2;
    public int speedbooster_from_bonus = 2;
    public int scorebooster_height = 2;
    private bool speedboosted = true;
    private Vector2 controldirection = Vector2.zero;
    public Rigidbody rb; // персонаж
    private int score = 0; // очки переменная
    private int bonusscore = 0;
    private int mainscore = 0;
    private GameObject block_pointer;
    private float PosX = 0.0f; //стартовая позиция персонажа по Х
    private float PosZ = 0.0f; //по Z
    private float PosY = 0.5f; //по Y
    private GameObject mblock; // объект для падающего блока
    private GameObject mbonusblock; //объект для бонус-блока
    public GameObject block; // подключене префаба падающего блока
    public GameObject bonusblock; //подключение префаба бонус-блока
    public int bonusblockspawncount = 10;
    private bool isfalling = false, randkey = true, isbonusfalling = false; // падает блок или нет / булл для генерации значения позиции
                                                    // падающего блока 
    private int blockcount = 0;
    private float h1=0.5f,h2=0.5f,h3=0.5f,h4=0.5f,h5=0.5f,h6=0.5f,h7=0.5f,h8=0.5f,h9=0.5f,curh=0.5f; // текущие высоты
                                    // стоящий блоков от которых будет спавниться новый блок / текущая высота персонажа
    public float speed, mnozh = 1f, spawnheight = 3f; //скорость падения / множитель / высота спавна блока
    private int randnum = 2, heropoz = 5; // позиция спавна блока / позиция персонажа / не используется
    private int bonusrandnum = 3;
    private float curcount1 = 0, curcount2 = 0, curcount3 = 0, curcount4 = 0, curcount5 = 0, curcount6 = 0, curcount7 = 0, curcount8 = 0, curcount9 = 0;
    public int layerscount = 1; //максимально количество заполненых блоками слоев
    private bool dirchosen = false;
    public Vector2 startPos;
    // счетчики сколько блоков подряд заспавнилось на конкретной позиции
    void Start()

    {  
        rebootbtn.SetActive(false);
        gui_score.text = "0"; // инициализация счета
        gui_game_over.text = " ";//инициализация текста конца игры
        rb = GetComponent<Rigidbody> ();
        PosY = PosY * mnozh; // расчет стартовой позиции персонажа по высоте
        rb.transform.position = new Vector3(PosX,PosY,PosZ); // выставление персонажа на стартовую позицию 
        
    }

    //функция перемещения персонажа, принимает направление перемещения (от 1 до 4)
    void MovePerson(int direction){
        // если на первой позиции есть 2 возможных направления перемещения
        // 1-вверх,2-вправо,3-вниз,4-влево
        if (heropoz == 1){
            //можем идти вправо
            if (direction == 2){
                if ((Mathf.Abs(h2 - curh) == 1f) || (Mathf.Abs(h2 - curh) == 0f)){
                    heropoz = 2; //меняем позицию персонажа
                    curh = h2; // меняем текущую высоты персонажа
                    PosX -= 3f * mnozh; // меняем Х персонажа
                    rb.transform.position = new Vector3(PosX,curh,PosZ); // перемещаем персонажа
                }
            } else if (direction == 3){
                if ((Mathf.Abs(h4 - curh) == 1f) || (Mathf.Abs(h4 - curh) == 0f)){
                    heropoz = 4;
                    curh = h4;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
            //дальше аналогично
        } else if (heropoz == 2){
            if (direction == 2){
                if ((Mathf.Abs(h3 - curh) == 1f) || (Mathf.Abs(h3 - curh) == 0f)){
                    heropoz = 3;
                    curh = h3;
                    PosX -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 3){
                if ((Mathf.Abs(h5 - curh) == 1f) || (Mathf.Abs(h5 - curh) == 0f)){
                    heropoz = 5;
                    curh = h5;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h1 - curh) == 1f) || (Mathf.Abs(h1 - curh) == 0f)){
                    heropoz = 1;
                    curh = h1;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 3){
            if (direction == 3){
                if ((Mathf.Abs(h6 - curh) == 1f) || (Mathf.Abs(h6 - curh) == 0f)){
                    heropoz = 6;
                    curh = h6;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h2 - curh) == 1f) || (Mathf.Abs(h2 - curh) == 0f)){
                    heropoz = 2;
                    curh = h2;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 4){
            if (direction == 1){
                if ((Mathf.Abs(h1 - curh) == 1f) || (Mathf.Abs(h1 - curh) == 0f)){
                    heropoz = 1;
                    curh = h1;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 2){
                if ((Mathf.Abs(h5 - curh) == 1f) || (Mathf.Abs(h5 - curh) == 0f)){
                    heropoz = 5;
                    curh = h5;
                    PosX -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 3){
                if ((Mathf.Abs(h7 - curh) == 1f) || (Mathf.Abs(h7 - curh) == 0f)){
                    heropoz = 7;
                    curh = h7;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 5){
            if (direction == 1){
                if ((Mathf.Abs(h2 - curh) == 1f) || (Mathf.Abs(h2 - curh) == 0f)){
                    heropoz = 2;
                    curh = h2;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 2){
                if ((Mathf.Abs(h6 - curh) == 1f) || (Mathf.Abs(h6 - curh) == 0f)){
                    heropoz = 6;
                    curh = h6;
                    PosX -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 3){
                if ((Mathf.Abs(h8 - curh) == 1f) || (Mathf.Abs(h8 - curh) == 0f)){
                    heropoz = 8;
                    curh = h8;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h4 - curh) == 1f) || (Mathf.Abs(h4 - curh) == 0f)){
                    heropoz = 4;
                    curh = h4;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 6){
            if (direction == 1){
                if ((Mathf.Abs(h3 - curh) == 1f) || (Mathf.Abs(h3 - curh) == 0f)){
                    heropoz = 3;
                    curh = h3;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h5 - curh) == 1f) || (Mathf.Abs(h5 - curh) == 0f)){
                    heropoz = 5;
                    curh = h5;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 3){
                if ((Mathf.Abs(h9 - curh) == 1f) || (Mathf.Abs(h9 - curh) == 0f)){
                    heropoz = 9;
                    curh = h9;
                    PosZ += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 7){
            if (direction == 2){
                if ((Mathf.Abs(h8 - curh) == 1f) || (Mathf.Abs(h8 - curh) == 0f)){
                    heropoz = 8;
                    curh = h8;
                    PosX -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 1){
                if ((Mathf.Abs(h4 - curh) == 1f) || (Mathf.Abs(h4 - curh) == 0f)){
                    heropoz = 4;
                    curh = h4;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 8){
            if (direction == 2){
                if ((Mathf.Abs(h9 - curh) == 1f) || (Mathf.Abs(h9 - curh) == 0f)){
                    heropoz = 9;
                    curh = h9;
                    PosX -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 1){
                if ((Mathf.Abs(h5 - curh) == 1f) || (Mathf.Abs(h5 - curh) == 0f)){
                    heropoz = 5;
                    curh = h5;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h7 - curh) == 1f) || (Mathf.Abs(h7 - curh) == 0f)){
                    heropoz = 7;
                    curh = h7;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        } else if (heropoz == 9){
            if (direction == 1){
                if ((Mathf.Abs(h6 - curh) == 1f) || (Mathf.Abs(h6 - curh) == 0f)){
                    heropoz = 6;
                    curh = h6;
                    PosZ -= 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            } else if (direction == 4){
                if ((Mathf.Abs(h8 - curh) == 1f) || (Mathf.Abs(h8 - curh) == 0f)){
                    heropoz = 8;
                    curh = h8;
                    PosX += 3f * mnozh;
                    rb.transform.position = new Vector3(PosX,curh,PosZ);
                }
            }
        }
    // если счет меньше текущей высоты меняем счет
    if (score < curh){
        score =(int) curh;
        mainscore = bonusscore + score;
        gui_score.text = mainscore.ToString();
    }
    }

    // ф-ия конец игры
    void endgame(){
        Debug.Log("end game");
       
        rebootbtn.SetActive(true);
        

        gui_game_over.text="GAME OVER TAP TO REBOOT";
        Time.timeScale = 0;

    }
      public void restart_scene(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        
         }

    // Update is called once per frame

    void OnTriggerEnter(Collider bonuscollider){
        if (bonuscollider.gameObject.name == "bonusblock Variant(Clone)"){
            speed += speedbooster_from_bonus;
            bonusscore += 10;
            mainscore = bonusscore + score;
            gui_score.text =mainscore.ToString();
            Destroy(bonuscollider.gameObject);
            isbonusfalling = false;
        }
        
    }
    void Update()
    {
        if (speedboosted){
            if ((mainscore % scorebooster_height == 0) && (mainscore != 0)){
                speed += speedbooster_from_height;
                speedboosted = false;
            } else {
                speedboosted = true;
            }
        }
        if (Input.touchCount > 0){
            Touch myTouch = Input.GetTouch(0);
            switch (myTouch.phase){
                case TouchPhase.Began:
                    dirchosen = false;
                    startPos = myTouch.position;
                    break;
                case TouchPhase.Moved:
                    dirchosen = false; 
                    controldirection = myTouch.position - startPos;
                    break;
                case TouchPhase.Ended:
                    dirchosen = true;
                    break;
            }

            if (dirchosen){
                if ((controldirection.x < 0 ) && (controldirection.y > 0)){
                    Anim.SetBool("isJump",true);
                    MovePerson(1);
                } else if ((controldirection.x > 0) && (controldirection.y > 0)){
                    Anim.SetBool("isJump",true);                    
                    MovePerson(2); 
                } else if ((controldirection.x > 0) && (controldirection.y < 0)){
                    Anim.SetBool("isJump",true);
                    MovePerson(3); 
                } else if ((controldirection.x < 0) && (controldirection.y < 0)){
                    Anim.SetBool("isJump",true);                    
                    MovePerson(4);
                }
            }
        }
        //считываем нажатие, вызываем ф-ию перемещения
        if((Input.GetKeyDown(KeyCode.UpArrow)) && (PosZ > -2.5f * mnozh)){
            
            Anim.SetBool("isJump",true);
            MovePerson(1);
            

        } else if((Input.GetKeyDown(KeyCode.DownArrow)) && (PosZ < 2.5f * mnozh)){
           
            Anim.SetBool("isJump",true);
            MovePerson(3);
            

        } else if((Input.GetKeyDown(KeyCode.LeftArrow)) && (PosX < 2.5f * mnozh)){
            Anim.SetBool("isJump",true);
            MovePerson(4);
           
          
        } else if((Input.GetKeyDown(KeyCode.RightArrow)) && (PosX > -2.5f * mnozh)){
          
           Anim.SetBool("isJump",true);
            MovePerson(2);
         
          
        }
        else { Anim.SetBool("isJump",false);
        }
        

        //падает ли блок в данный момент
        if (!isfalling){
            //падающего блока нет, генерируем новый
            // если есть 1 заполненный слой, вычитаем 1 из всех счетчиков
            if ((curcount1 >= 1) && (curcount2 >= 1) && (curcount3 >= 1) && (curcount4 >= 1) && (curcount5 >= 1) && (curcount6 >= 1) && (curcount7 >= 1) && (curcount8 >= 1) && (curcount9 >= 1)){
                curcount9 -= 1;
                curcount8 -= 1;
                curcount7 -= 1;
                curcount6 -= 1;
                curcount5 -= 1;
                curcount4 -= 1;
                curcount3 -= 1;
                curcount2 -= 1;
                curcount1 -= 1;
            }

            // проверка на конец игры
            if (mblock){
                // блок падает на перса, и перс с блоком в одной позиции
                if ((mblock.transform.position.y - curh <= 1) && (randnum == heropoz)){
                    // конец игры
                    endgame();
                }
            }

            // генерация позиции нового блока с учетом того что не может упасть больше 2х блоков на одну позицию
            while (randkey){
                randnum = Random.Range(1, 10);
                if ((randnum == 1) && (curcount1 <= layerscount)){
                    curcount1 += 1; //+1 к кол-ву блоков на 1 позиции
                    randkey = false; // выход из цикла
                    break;
                }
                if ((randnum == 2) && (curcount2 <= layerscount)){
                    curcount2 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 3) && (curcount3 <= layerscount)){
                    curcount3 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 4) && (curcount4 <= layerscount)){
                    curcount4 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 5) && (curcount5 <= layerscount)){
                    curcount5 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 6) && (curcount6 <= layerscount)){
                    curcount6 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 7) && (curcount7 <= layerscount)){
                    curcount7 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 8) && (curcount8 <= layerscount)){
                    curcount8 += 1;
                    randkey = false;
                    break;
                }
                if ((randnum == 9) && (curcount9 <= layerscount)){
                    curcount9 += 1;
                    randkey = false;
                    break;
                }
            }
            randkey = true; // включаем цикл генерации на следующий раз
            mblock = Instantiate(block) as GameObject; //создаем новый блок
            block_pointer = Instantiate(pref_block_pointer) as GameObject;
            blockcount += 1;
            // в зависимости от сгенерированной позиции устанавливаем координаты блока
            if (randnum == 1){
                mblock.transform.position = new Vector3(3f * mnozh,h1 + spawnheight,-3f * mnozh);
                block_pointer.transform.position = new Vector3(3f, h1 - 0.5f, -3f);
            } else if (randnum == 2){
                mblock.transform.position = new Vector3(0.0f,h2 + spawnheight,-3f * mnozh);
                block_pointer.transform.position = new Vector3(0f, h2 - 0.5f, -3f);
            } else if (randnum == 3){
                mblock.transform.position = new Vector3(-3f * mnozh,h3 + spawnheight,-3f * mnozh);
                block_pointer.transform.position = new Vector3(-3f, h3 - 0.5f, -3f);
            } else if (randnum == 4){
                mblock.transform.position = new Vector3(3f * mnozh,h4 + spawnheight,0.0f);
                block_pointer.transform.position = new Vector3(3f, h4 - 0.5f, 0f);
            } else if (randnum == 5){
                mblock.transform.position = new Vector3(0.0f,h5 + spawnheight,0.0f);
                block_pointer.transform.position = new Vector3(0f, h5 - 0.5f, 0f);
            } else if (randnum == 6){
                mblock.transform.position = new Vector3(-3f * mnozh,h6 + spawnheight,0.0f);
                block_pointer.transform.position = new Vector3(-3f, h6 - 0.5f, 0f);
            } else if (randnum == 7){
                mblock.transform.position = new Vector3(3f * mnozh,h7 + spawnheight,3f * mnozh);
                block_pointer.transform.position = new Vector3(3f, h7 - 0.5f, 3f);
            } else if (randnum == 8){
                mblock.transform.position = new Vector3(0.0f,h8 + spawnheight,3f * mnozh);
                block_pointer.transform.position = new Vector3(0f, h8 - 0.5f, 3f);
            } else if (randnum == 9){
                mblock.transform.position = new Vector3(-3f * mnozh,h9 + spawnheight,3f * mnozh);
                block_pointer.transform.position = new Vector3(-3f, h9 - 0.5f, 3f);
            }
            isfalling = true; // блок падает
        } else {
            // каждый кадр двигаем блок вниз
            mblock.transform.Translate(Vector3.down * speed * Time.deltaTime);
            // в зависимости от позиции смотрим упал ли блок
            if (randnum == 1){
                if (mblock.transform.position.y < h1){
                    mblock.transform.position = new Vector3(3f * mnozh,h1,-3f * mnozh); // блок упал, ставим его
                    h1 += 1f * mnozh; // меняем высоты позиции
                    isfalling = false; // блок упал, нужно генерировать новый
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 2){
                if (mblock.transform.position.y < h2){
                    mblock.transform.position = new Vector3(0.0f,h2,-3f * mnozh);
                    h2 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 3){
                if (mblock.transform.position.y < h3){
                    mblock.transform.position = new Vector3(-3f * mnozh,h3,-3f * mnozh);
                    h3 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 4){
                if (mblock.transform.position.y < h4){
                    mblock.transform.position = new Vector3(3f * mnozh,h4,0.0f);
                    h4 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 5){
                if (mblock.transform.position.y < h5){
                    mblock.transform.position = new Vector3(0.0f,h5,0.0f);
                    h5 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 6){
                if (mblock.transform.position.y < h6){
                    mblock.transform.position = new Vector3(-3f * mnozh,h6,0.0f);
                    h6 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 7){
                if (mblock.transform.position.y < h7){
                    mblock.transform.position = new Vector3(3f * mnozh,h7,3f * mnozh);
                    h7 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 8){
                if (mblock.transform.position.y < h8){
                    mblock.transform.position = new Vector3(0.0f,h8,3f * mnozh);
                    h8 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            } else if (randnum == 9){
                if (mblock.transform.position.y < h9){
                    mblock.transform.position = new Vector3(-3f * mnozh,h9,3f * mnozh);
                    h9 += 1f * mnozh;
                    isfalling = false;
                    Destroy(block_pointer.gameObject);
                }
            }
        }
        if (!isbonusfalling){
            if (blockcount % bonusblockspawncount == 0){
                while(randkey){
                    bonusrandnum = Random.Range(1,10);
                    if(randnum != bonusrandnum){
                        randkey = false;
                    }
                }
                randkey = true;
                mbonusblock = Instantiate(bonusblock) as GameObject;
                if (bonusrandnum == 1){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h1 + spawnheight,-3f * mnozh);
                } else if (bonusrandnum == 2){
                    mbonusblock.transform.position = new Vector3(0.0f,h2 + spawnheight,-3f * mnozh);
                } else if (bonusrandnum == 3){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h3 + spawnheight,-3f * mnozh);
                } else if (bonusrandnum == 4){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h4 + spawnheight,0.0f);
                } else if (bonusrandnum == 5){
                    mbonusblock.transform.position = new Vector3(0.0f,h5 + spawnheight,0.0f);
                } else if (bonusrandnum == 6){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h6 + spawnheight,0.0f);
                } else if (bonusrandnum == 7){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h7 + spawnheight,3f * mnozh);
                } else if (bonusrandnum == 8){
                    mbonusblock.transform.position = new Vector3(0.0f,h8 + spawnheight,3f * mnozh);
                } else if (bonusrandnum == 9){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h9 + spawnheight,3f * mnozh);
                }
                isbonusfalling = true;
            }
        }else{
            mbonusblock.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (bonusrandnum == 1){
                if (mbonusblock.transform.position.y < h1){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h1,-3f * mnozh); // блок упал, ставим его
                    isbonusfalling = false; // блок упал, нужно генерировать новый
                }
            } else if (bonusrandnum == 2){
                if (mbonusblock.transform.position.y < h2){
                    mbonusblock.transform.position = new Vector3(0.0f,h2,-3f * mnozh);
                    isbonusfalling = false;;
                }
            } else if (bonusrandnum == 3){
                if (mbonusblock.transform.position.y < h3){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h3,-3f * mnozh);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 4){
                if (mbonusblock.transform.position.y < h4){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h4,0.0f);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 5){
                if (mbonusblock.transform.position.y < h5){
                    mbonusblock.transform.position = new Vector3(0.0f,h5,0.0f);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 6){
                if (mbonusblock.transform.position.y < h6){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h6,0.0f);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 7){
                if (mbonusblock.transform.position.y < h7){
                    mbonusblock.transform.position = new Vector3(3f * mnozh,h7,3f * mnozh);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 8){
                if (mbonusblock.transform.position.y < h8){
                    mbonusblock.transform.position = new Vector3(0.0f,h8,3f * mnozh);
                    isbonusfalling = false;
                }
            } else if (bonusrandnum == 9){
                if (mbonusblock.transform.position.y < h9){
                    mbonusblock.transform.position = new Vector3(-3f * mnozh,h9,3f * mnozh);
                    isbonusfalling = false;
                }
            }
        }

        
    }

}

@Entity
@Table(name="team")

@Id
@GeneratedValue(strategy = GenerationType.IDENTITY)

@Column(nullable = false, unique = true)
@Column(name="name",length=32)

@Enumerated(EnumType.STRING) 
@Column(nullable = true)
private UserType type;

@Transient
private String  userName;
--------------------------------
@OneToOne(cascade=CascadeType.ALL)//People是关系的维护端，当删除 people，会级联删除 address
@JoinColumn(name = "address_id", referencedColumnName = "id")//people中的address_id字段参考address表中的id字段
private Address address;//地址

@OneToOne(cascade=CascadeType.ALL)//People是关系的维护端
@JoinTable(name = "people_address",
        joinColumns = @JoinColumn(name="people_id"),
        inverseJoinColumns = @JoinColumn(name = "address_id"))//通过关联表保存一对一的关系
private Address address;//地址

//如果不需要根据Address级联查询People，可以注释掉
@OneToOne(mappedBy = "address", cascade = {CascadeType.MERGE, CascadeType.REFRESH}, optional = false)
private People people;
------------------------------------

@OneToMany(mappedBy = "author",cascade=CascadeType.ALL,fetch=FetchType.LAZY)
//级联保存、更新、删除、刷新;延迟加载。当删除用户，会级联删除该用户的所有文章
//拥有mappedBy注解的实体类为关系被维护端
 //mappedBy="author"中的author是Article中的author属性
private List<Article> articleList;//文章列表

@ManyToOne(cascade={CascadeType.MERGE,CascadeType.REFRESH},optional=false)//可选属性optional=false,表示author不能为空。删除文章，不影响用户
@JoinColumn(name="author_id")//设置在article表中的关联字段(外键)
private Author author;//所属作者

---------------------------------------------------



@OneToMany(mappedBy="team",cascade=CascadeType.ALL,fetch=FetchType.LAZY)
private Set<Player> players = new HashSet<Player>();
SELECT DISTINCT t FROM Team t JOIN t.players p where p.name LIKE :name;
SELECT DISTINCT t FROM Team t,IN(t.players) p WHERE p.name LIKE :name

@ManyToOne(cascade={CascadeType.MERGE,CascadeType.REFRESH})
@JoinColumn(name="team_id")
private Team team;
SELECT p FROM Player p JOIN p.team t WHERE t.id = :id; //tow sql
SELECT p FROM Player p, IN(p.team) t WHERE t.id = :id;

SELECT p FROM Player p JOIN FETCH p.team t WHERE t.id = :id//one sql

---------------------------------------------------
/*
1、多对多关系中一般不设置级联保存、级联删除、级联更新等操作。

2、可以随意指定一方为关系维护端，在这个例子中，我指定 User 为关系维护端，所以生成的关联表名称为： user_authority，关联表的字段为：user_id 和 authority_id。

3、多对多关系的绑定由关系维护端来完成，即由 User.setAuthorities(authorities) 来绑定多对多的关系。关系被维护端不能绑定关系，即Game不能绑定关系。

4、多对多关系的解除由关系维护端来完成，即由Player.getGames().remove(game)来解除多对多的关系。关系被维护端不能解除关系，即Game不能解除关系。

5、如果 User 和 Authority 已经绑定了多对多的关系，那么不能直接删除 Authority，需要由 User 解除关系后，才能删除 Authority。但是可以直接删除 User，因为 User 是关系维护端，删除 User 时，会先解除 User 和 Authority 的关系，再删除 Authority。
*/
@ManyToMany
@JoinTable(name = "user_authority",joinColumns = @JoinColumn(name = "user_id"),
inverseJoinColumns = @JoinColumn(name = "authority_id"))
//1、关系维护端，负责多对多关系的绑定和解除
//2、@JoinTable注解的name属性指定关联表的名字，joinColumns指定外键的名字，关联到关系维护端(User)
//3、inverseJoinColumns指定外键的名字，要关联的关系被维护端(Authority)
//4、其实可以不使用@JoinTable注解，默认生成的关联表名称为主表表名+下划线+从表表名，
//即表名为user_authority
//关联到主表的外键名：主表名+下划线+主表中的主键列名,即user_id
//关联到从表的外键名：主表中用于关联的属性名+下划线+从表的主键列名,即authority_id
//主表就是关系维护端对应的表，从表就是关系被维护端对应的表
private List<Authority> authorityList;

@ManyToMany(mappedBy = "authorityList")
private List<User> userList;

-----------------------------------
/*
其中 @OneToMany  和 @ManyToOne 用得最多，这里再补充一下

 

关于级联，一定要注意，要在关系的维护端，即 One 端。

比如 作者和文章，作者是One，文章是Many；文章和评论，文章是One，评论是Many。

cascade = CascadeType.ALL 只能写在 One 端，只有One端改变Many端，不准Many端改变One端。

特别是删除，因为 ALL 里包括更新，删除。

如果删除一条评论，就把文章删了，那算谁的。所以，在使用的时候要小心。一定要在 One 端使用。
*/
----------------------------------------------------------
Page<User> findByUserName(String userName,Pageable pageable);
public void testPageQuery() throws Exception {
	int page=1,size=10;
	Sort sort = new Sort(Direction.DESC, "id");
    Pageable pageable = new PageRequest(page, size, sort);
    userRepository.findALL(pageable);
    userRepository.findByUserName("testName", pageable);
}

@Query(value = "SELECT * FROM USERS WHERE LASTNAME = ?1",
countQuery = "SELECT count(*) FROM USERS WHERE LASTNAME = ?1",
nativeQuery = true)
Page<User> findByLastname(String lastname, Pageable pageable);

@Query(value = "select b.roomUid from RoomBoard b where b.userId=:userId and b.lastBoard=true order by  b.createTime desc")
Page<String> findRoomUidsByUserIdPageable(@Param("userId") long userId, Pageable pageable);

//查询2个表的指定字段，组成新的对象UserInfo
@Query(value = "select new com.cxx.beans.UserInfo(u.userid, u.phone,u.name, u.address, u.info,head.headUrl) "
		+ "from AppUser u, HeadUrl head where u.userid = head.userid and"
		+ " u.userid = :userid")
UserInfo  findUserInfoByUserid(@Param("userid") String userid);

@Query(value = "select u.userid, u.phone,u.name, u.address, u.info,head.headUrl from AppUser u, HeadUrl head"
			+ " where u.userid = head.userid and"
			+ " u.userid = :userid",nativeQuery = true)
List<Object[]>  findUserInfos2(@Param("userid") String userid);

@Modifying
@Transactional
@Query(value="delete from AppUser where name =?1 and city= ?2")
void deleteUser(String name,String city);


public interface HotelSummary {
	City getCity();
	String getName();
	Double getAverageRating();
	default Integer getAverageRatingRounded() {
		return getAverageRating() == null ? null : (int) Math.round(getAverageRating());
	}
}
@Query("select h.city as city, h.name as name, avg(r.rating) as averageRating "
		- "from Hotel h left outer join h.reviews r where h.city = ?1 group by h")
Page<HotelSummary> findByCity(City city, Pageable pageable);

@Query("select new map(s.userid) from AppStudyRecodTable s,LoadVideoTable l where s.userid = ?1")
public List<Map<String,Object>> findByUserid(int userid);

---------------------------------------------------------------
import org.springframework.stereotype.Repository;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;
 
@Repository
public class EntityManagerDAO {
 
    @PersistenceContext
    private EntityManager entityManager;
 
 
    @Transactional
    public List<BackstageUserListDTO> listUser(){
        String sql = "select a.create_time createTime," +
                "a.mobilephone phoneNum," +
                "a.email email,a.uid uid," +
                "a.enabled enabled," +
                "c.id_number idNumber," +
                " (case b.`status` when 1 then 1 else 0 end) status " +
                "from tbl_sys_user a " +
                "LEFT JOIN user_high_qic b on a.uid=b.u_id" +
                "LEFT JOIN user_qic c on a.uid=c.uid " +
                "ORDER BY status desc";
 
        SQLQuery sqlQuery = entityManager.createNativeQuery(sql).unwrap(SQLQuery.class);
        Query query = 
     sqlQuery.setResultTransformer(Transformers.aliasToBean(BackstageUserListDTO.class));
        List<BackstageUserListDTO> list = query.list();
        entityManager.clear();
        return list;
    }
}
---------------------------------------------------------
Specification<User> specification = new Specification<User>() {
@Override
public Predicate toPredicate(Root<User> root, CriteriaQuery<?> query, CriteriaBuilder cb) {
    List<Predicate> predicates = new ArrayList<>(); //所有的断言
    if(StringUtils.isNotBlank(nickName)){ //添加断言
        Predicate likeNickName = cb.like(root.get("nickName").as(String.class),nickName+"%");
        predicates.add(likeNickName);
    }
    return cb.and(predicates.toArray(new Predicate[0]));
}
};
----------------------------------------------------------
@Service
@Transactional
public class IncomeService{

    /**
     * 实体管理对象
     */
    @PersistenceContext
    EntityManager entityManager;

    public Page<IncomeDaily> findIncomeDailysByPage(PageParam pageParam, String cpId, String appId, Date start, Date end, String sp) {
        StringBuilder countSelectSql = new StringBuilder();
        countSelectSql.append("select count(*) from IncomeDaily po where 1=1 ");

        StringBuilder selectSql = new StringBuilder();
        selectSql.append("from IncomeDaily po where 1=1 ");

        Map<String,Object> params = new HashMap<>();
        StringBuilder whereSql = new StringBuilder();
        if(StringUtils.isNotBlank(cpId)){
            whereSql.append(" and cpId=:cpId ");
            params.put("cpId",cpId);
        }
        if(StringUtils.isNotBlank(appId)){
            whereSql.append(" and appId=:appId ");
            params.put("appId",appId);
        }
        if(StringUtils.isNotBlank(sp)){
            whereSql.append(" and sp=:sp ");
            params.put("sp",sp);
        }
        if (start == null)
        {
            start = DateUtil.getStartOfDate(new Date());
        }
        whereSql.append(" and po.bizDate >= :startTime");
        params.put("startTime", start);

        if (end != null)
        {
            whereSql.append(" and po.bizDate <= :endTime");
            params.put("endTime", end);
        }

        String countSql = new StringBuilder().append(countSelectSql).append(whereSql).toString();
        Query countQuery = this.entityManager.createQuery(countSql,Long.class);
        this.setParameters(countQuery,params);
        Long count = (Long) countQuery.getSingleResult();

        String querySql = new StringBuilder().append(selectSql).append(whereSql).toString();
        Query query = this.entityManager.createQuery(querySql,IncomeDaily.class);
        this.setParameters(query,params);
        if(pageParam != null){ //分页
            query.setFirstResult(pageParam.getStart());
            query.setMaxResults(pageParam.getLength());
        }

        List<IncomeDaily> incomeDailyList = query.getResultList();
      if(pageParam != null) { //分页
            Pageable pageable = new PageRequest(pageParam.getPage(), pageParam.getLength());
            Page<IncomeDaily> incomeDailyPage = new PageImpl<IncomeDaily>(incomeDailyList, pageable, count);
            return incomeDailyPage;
        }else{ //不分页
            return new PageImpl<IncomeDaily>(incomeDailyList);
        }
    }

    /**
     * 给hql参数设置值
     * @param query 查询
     * @param params 参数
     */
    private void setParameters(Query query,Map<String,Object> params){
        for(Map.Entry<String,Object> entry:params.entrySet()){
            query.setParameter(entry.getKey(),entry.getValue());
        }
    }
}
----------------------------------------------------------
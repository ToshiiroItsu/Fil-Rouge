/*Creation de table*/
create schema if not exists public;

--
-- TOC entry 226 (class 1259 OID 38921)
-- Name: avis; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.avis (
    note integer NOT NULL,
    commentaire character varying(500),
    fk_recette integer NOT NULL,
    fk_utilisateur integer NOT NULL
);


ALTER TABLE public.avis OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 38887)
-- Name: categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories (
    id integer NOT NULL,
    nom character varying(50) NOT NULL
);


ALTER TABLE public.categories OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 38886)
-- Name: categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categories_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.categories_id_seq OWNER TO postgres;

--
-- TOC entry 3439 (class 0 OID 0)
-- Dependencies: 221
-- Name: categories_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categories_id_seq OWNED BY public.categories.id;


--
-- TOC entry 228 (class 1259 OID 38953)
-- Name: categories_recettes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories_recettes (
    fk_categorie integer NOT NULL,
    fk_recette integer NOT NULL
);


ALTER TABLE public.categories_recettes OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 38909)
-- Name: etapes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.etapes (
    numero integer NOT NULL,
    nom_etape text NOT NULL,
    texte text NOT NULL,
    fk_recette integer NOT NULL
);


ALTER TABLE public.etapes OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 38867)
-- Name: ingredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ingredients (
    id integer NOT NULL,
    nom character varying(50) NOT NULL
);


ALTER TABLE public.ingredients OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 38866)
-- Name: ingredients_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ingredients_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ingredients_id_seq OWNER TO postgres;

--
-- TOC entry 3440 (class 0 OID 0)
-- Dependencies: 217
-- Name: ingredients_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ingredients_id_seq OWNED BY public.ingredients.id;


--
-- TOC entry 227 (class 1259 OID 38938)
-- Name: ingredients_recettes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ingredients_recettes (
    quantite character varying(40),
    fk_ingredient integer NOT NULL,
    fk_recette integer NOT NULL
);


ALTER TABLE public.ingredients_recettes OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 38896)
-- Name: recettes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.recettes (
    id integer NOT NULL,
    nom character varying(100) NOT NULL,
    temps_preparation interval NOT NULL,
    temps_cuisson interval NOT NULL,
    difficulte character varying NOT NULL,
    cout character varying,
    description text,
    nombrepersonne integer,
    image character varying,
    fk_utilisateur integer
);


ALTER TABLE public.recettes OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 38895)
-- Name: recettes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.recettes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.recettes_id_seq OWNER TO postgres;

--
-- TOC entry 3441 (class 0 OID 0)
-- Dependencies: 223
-- Name: recettes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.recettes_id_seq OWNED BY public.recettes.id;


--
-- TOC entry 220 (class 1259 OID 38876)
-- Name: utilisateurs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.utilisateurs (
    id integer NOT NULL,
    identifiant character varying(20) NOT NULL,
    email character varying(50) NOT NULL,
    password character varying(500) NOT NULL,
    role character varying
);


ALTER TABLE public.utilisateurs OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 38875)
-- Name: utilisateurs_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.utilisateurs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.utilisateurs_id_seq OWNER TO postgres;

--
-- TOC entry 3442 (class 0 OID 0)
-- Dependencies: 219
-- Name: utilisateurs_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.utilisateurs_id_seq OWNED BY public.utilisateurs.id;


--
-- TOC entry 3243 (class 2604 OID 38890)
-- Name: categories id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories ALTER COLUMN id SET DEFAULT nextval('public.categories_id_seq'::regclass);


--
-- TOC entry 3241 (class 2604 OID 38870)
-- Name: ingredients id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients ALTER COLUMN id SET DEFAULT nextval('public.ingredients_id_seq'::regclass);


--
-- TOC entry 3244 (class 2604 OID 38899)
-- Name: recettes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recettes ALTER COLUMN id SET DEFAULT nextval('public.recettes_id_seq'::regclass);


--
-- TOC entry 3242 (class 2604 OID 38879)
-- Name: utilisateurs id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs ALTER COLUMN id SET DEFAULT nextval('public.utilisateurs_id_seq'::regclass);

/*Inserts */
--
-- TOC entry 3430 (class 0 OID 38921)
-- Dependencies: 226
-- Data for Name: avis; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.avis VALUES (5, ' Une vraie explosion de saveurs en bouche ! Les takoyaki étaient parfaitement doréset croustillants à l''extérieur, avec un cœur fondant et savoureux. Le mélange entre
la pâte moelleuse, le tendre morceau de poulpe et la sauce légèrement sucrée était juste parfait. Sans oublier la touche de bonite séchée qui apporte une saveur unique!
Un vrai régal, je recommande à 100 % !', 1, 1);
INSERT INTO public.avis VALUES (5, 'Les okonomiyaki sont une véritable explosion de saveurs !Cette crêpe japonaise allie le moelleux de la pâte, le croquant du chou et la gourmandise du bacon,
le tout sublimé par la sauce okonomiyaki et la mayonnaise japonaise. Chaque bouchée est un parfait équilibre entre umami,
douceur et texture. Facile à personnaliser avec différentes garnitures, c''est un plat convivial et réconfortant qui ravit à coup sûr les papilles.
Impossible d''y résister !', 2, 1);
INSERT INTO public.avis VALUES (2, 'Recette pas oufff.', 1, 2);
INSERT INTO public.avis VALUES (5, 'Un vrai régal ! Le bouillon était riche et savoureux, parfaitement équilibré entre umami et douceur. Les nouilles avaient une texture idéale, ni trop fermes ni trop molles, et les garnitures – surtout l’œuf mariné – étaient tout simplement délicieuses. Une belle claque gustative, je reviendrai sans hésiter', 4, 1);
INSERT INTO public.avis VALUES (4, 'Régalade', 4, 2);


--
-- TOC entry 3426 (class 0 OID 38887)
-- Dependencies: 222
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.categories VALUES (1, 'Entrées');
INSERT INTO public.categories VALUES (2, 'Plats principaux');
INSERT INTO public.categories VALUES (3, 'Desserts');
INSERT INTO public.categories VALUES (4, 'Soupes');
INSERT INTO public.categories VALUES (5, 'Légume');
INSERT INTO public.categories VALUES (6, 'Viande');
INSERT INTO public.categories VALUES (7, 'Poisson');
INSERT INTO public.categories VALUES (8, 'Frommage');
INSERT INTO public.categories VALUES (9, 'Fruit');
INSERT INTO public.categories VALUES (10, 'Chocolat');
INSERT INTO public.categories VALUES (11, 'Végétarien');
INSERT INTO public.categories VALUES (12, 'Sans Gluten');
INSERT INTO public.categories VALUES (13, 'Sans Sucre');
INSERT INTO public.categories VALUES (14, 'Sans Lactose');


--
-- TOC entry 3432 (class 0 OID 38953)
-- Dependencies: 228
-- Data for Name: categories_recettes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.categories_recettes VALUES (2, 4);
INSERT INTO public.categories_recettes VALUES (1, 1);
INSERT INTO public.categories_recettes VALUES (2, 2);


--
-- TOC entry 3429 (class 0 OID 38909)
-- Dependencies: 225
-- Data for Name: etapes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.etapes VALUES (1, 'Préparer la pâte', ' Dans un grand bol, mélangez la farine, le sel et la levure chimique. Ajoutez ensuite l''œuf, la sauce soja et le bouillon dashi.
Fouettez jusqu''à obtenir une pâte lisse et homogène. ', 1);
INSERT INTO public.etapes VALUES (2, 'Chauffer la plaque à takoyaki', 'Faites chauffer une plaque à takoyaki et huilez généreusement chaque
alvéole à l''aide d''un pinceau ou d''un essuie-tout imbibé d''huile. ', 1);
INSERT INTO public.etapes VALUES (3, 'Cuisson des takoyaki', 'Versez la pâte dans les alvéoles jusqu''à ce qu''elles soient presque pleines. Ajoutez un morceau de poulpe, un peu d''oignon vert,
du tenkasu et du gingembre mariné dans chaque boule. ', 1);
INSERT INTO public.etapes VALUES (4, 'Former les boules', 'Lorsque la base commence à cuire, utilisez une brochette ou un pic pour retourner chaque takoyaki délicatement.
Continuez à les faire tourner régulièrement jusqu''à ce qu''ils soient bien dorés et ronds. ', 1);
INSERT INTO public.etapes VALUES (5, 'Servir', 'Disposez les takoyaki sur une assiette, nappez-les de sauce takoyaki et de mayonnaise japonaise. Saupoudrez de flocons de bonite et d''algue nori.
Dégustez chaud et savourez ce délice japonais chez vous ! Bon appétit ! ', 1);
INSERT INTO public.etapes VALUES (1, 'Préparer la pâte', 'Dans un bol, mélange la farine, la levure et le dashi jusqu''à obtenir une pâte lisse. Ajoute les œufs et mélange bien.', 2);
INSERT INTO public.etapes VALUES (2, 'Ajouter les légumes', 'Incorpore le chou émincé et les oignons nouveaux à la pâte. Ajoute la sauce soja et mélange délicatement.', 2);
INSERT INTO public.etapes VALUES (3, 'Cuisson', 'Chauffe une poêle légèrement huilée à feu moyen. Verse une portion de pâte et forme une galette ronde d"environ 2 cm d''épaisseur.
Dépose 2-3 tranches de bacon sur le dessus. Couvre et laisse cuire 5 minutes. Retourne délicatement et cuis encore 5 minutes.', 2);
INSERT INTO public.etapes VALUES (4, 'Dressage', 'Dépose l''okonomiyaki dans une assiette. Ajoute la sauce okonomiyaki en zigzag, puis la mayonnaise. Saupoudre de katsuobushi et de poudre de nori.
', 2);
INSERT INTO public.etapes VALUES (5, 'Déguster', 'Déguster bien chaud avec des baguettes !', 2);
INSERT INTO public.etapes VALUES (1, 'Préparer le bouillon', 'Dans une grande casserole, faites chauffer l’huile de sésame et faites revenir l’ail haché et l’oignon vert jusqu’à ce qu’ils soient tendres et parfumés.

Ajoutez le bouillon (poulet, porc ou végétarien) et portez à ébullition. Réduisez ensuite le feu pour laisser mijoter quelques minutes.

Incorporez la pâte de miso, la sauce soja, et le mirin (si vous l’utilisez). Mélangez bien pour dissoudre le miso.', 4);
INSERT INTO public.etapes VALUES (2, 'Cuire les nouilles', 'Dans une autre casserole, faites bouillir de l''eau salée et faites cuire les nouilles ramen selon les instructions du paquet. Une fois cuites, égouttez-les et réservez.', 4);
INSERT INTO public.etapes VALUES (3, 'Cuire l''œuf ', 'Faites bouillir un œuf dans de l''eau pendant 6-7 minutes pour un œuf mollet. Plongez-le dans de l''eau froide pour stopper la cuisson. Écalez-le délicatement une fois refroidi.', 4);
INSERT INTO public.etapes VALUES (4, 'Assembler le ramen', 'Répartissez les nouilles dans les bols.

Versez le bouillon chaud dessus.

Ajoutez les tranches de viande (porc ou poulet) et les légumes (champignons, pousses de bambou, épinards, etc.).

Coupez l''œuf mollet en deux et placez-le sur le dessus.

Garnissez avec des oignons verts, du nori, et éventuellement un peu de sauce soja ou d''huile de sésame.', 4);


--
-- TOC entry 3422 (class 0 OID 38867)
-- Dependencies: 218
-- Data for Name: ingredients; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ingredients VALUES (1, 'Farine');
INSERT INTO public.ingredients VALUES (2, 'Oeuf');
INSERT INTO public.ingredients VALUES (3, 'Bouillon de Dashi');
INSERT INTO public.ingredients VALUES (4, 'Sauce Soja');
INSERT INTO public.ingredients VALUES (5, 'Sel');
INSERT INTO public.ingredients VALUES (6, 'Levure Chimique');
INSERT INTO public.ingredients VALUES (7, 'Poulpe cuit, coupé en petits morceaux');
INSERT INTO public.ingredients VALUES (8, 'Oignon Verts émincés');
INSERT INTO public.ingredients VALUES (10, 'Gingembre mariné(Beni shoga)');
INSERT INTO public.ingredients VALUES (11, 'Sauce Takoyaki (ou sauce okonomiyaki)');
INSERT INTO public.ingredients VALUES (12, 'Mayonnaise Japonaise(Kewpie)');
INSERT INTO public.ingredients VALUES (13, 'Flocons de bonite séchée (katsuobushi)');
INSERT INTO public.ingredients VALUES (14, 'Poudre d\"algue nori (aonori)');
INSERT INTO public.ingredients VALUES (15, 'Chou émincé');
INSERT INTO public.ingredients VALUES (16, 'Oignons nouveaux (ciboule)');
INSERT INTO public.ingredients VALUES (17, 'Bacon en tranches');
INSERT INTO public.ingredients VALUES (18, 'Nouilles ramen (ou des nouilles de votre choix)');
INSERT INTO public.ingredients VALUES (19, 'Bouillon (de poulet...)');
INSERT INTO public.ingredients VALUES (20, 'D’huile de sésame');
INSERT INTO public.ingredients VALUES (21, 'Pâte de miso');
INSERT INTO public.ingredients VALUES (22, 'Oeuf (à cuire mollet)');
INSERT INTO public.ingredients VALUES (9, 'Tempura(tenkatsu)');


--
-- TOC entry 3431 (class 0 OID 38938)
-- Dependencies: 227
-- Data for Name: ingredients_recettes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ingredients_recettes VALUES ('150g', 1, 1);
INSERT INTO public.ingredients_recettes VALUES ('1', 2, 1);
INSERT INTO public.ingredients_recettes VALUES ('350 ml', 3, 1);
INSERT INTO public.ingredients_recettes VALUES ('1 cuillére à soupe de', 4, 1);
INSERT INTO public.ingredients_recettes VALUES ('1/2 cuillére à café de', 5, 1);
INSERT INTO public.ingredients_recettes VALUES ('1/2 cuillére à café de', 6, 1);
INSERT INTO public.ingredients_recettes VALUES ('100 g de', 7, 1);
INSERT INTO public.ingredients_recettes VALUES ('2', 8, 1);
INSERT INTO public.ingredients_recettes VALUES ('50 g', 9, 1);
INSERT INTO public.ingredients_recettes VALUES ('1 cuillére à soupe de', 10, 1);
INSERT INTO public.ingredients_recettes VALUES ('150 g', 1, 2);
INSERT INTO public.ingredients_recettes VALUES ('1/2 sachet', 6, 2);
INSERT INTO public.ingredients_recettes VALUES ('100 ml', 3, 2);
INSERT INTO public.ingredients_recettes VALUES ('2', 2, 2);
INSERT INTO public.ingredients_recettes VALUES ('200 g', 15, 2);
INSERT INTO public.ingredients_recettes VALUES ('2', 16, 2);
INSERT INTO public.ingredients_recettes VALUES ('100 g', 17, 2);
INSERT INTO public.ingredients_recettes VALUES ('1 cuillère à soupe de', 4, 2);
INSERT INTO public.ingredients_recettes VALUES ('1 cuillère à soupe de', 12, 2);
INSERT INTO public.ingredients_recettes VALUES ('200 g de', 18, 4);
INSERT INTO public.ingredients_recettes VALUES ('1 litre de', 19, 4);
INSERT INTO public.ingredients_recettes VALUES ('1 cuillère à soupe', 20, 4);
INSERT INTO public.ingredients_recettes VALUES ('2 cuillères à soupe de', 21, 4);
INSERT INTO public.ingredients_recettes VALUES ('1', 22, 4);


--
-- TOC entry 3428 (class 0 OID 38896)
-- Dependencies: 224
-- Data for Name: recettes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.recettes VALUES (4, 'Recette authentique de Ramen', '00:15:00', '00:20:00', 'Intermédiaire', 'Bon marché', 'Les ramen sont une spécialité japonaise incontournable, composée de nouilles savoureuses servies dans un bouillon parfumé.
Voici une recette simple et délicieuse à essayer chez vous !', 2, '/images/recettes/mhwouv0h.webp', 1);
INSERT INTO public.recettes VALUES (1, 'Recette authentique de Takoyaki', '00:15:00', '00:20:00', 'Facile', 'Bon marché', 'Les takoyaki sont de délicieuses boulettes japonaises à base de pâte et de poulpe, très populaires à Osaka.
 Voici une recette simple pour les préparer chez vous !', 4, '/images/recettes/Takoyaki.png', 1);
INSERT INTO public.recettes VALUES (2, 'Recette authentique d''Okonomiyaki', '00:15:00', '00:10:00', 'Difficile', 'Bon marché', 'L''Okonomiyaki est une savoureuse crêpe japonaise garnie de divers ingrédients.
Très populaire à Osaka et Hiroshima,cette recette facile vous permettra de la préparer chez vous !', 4, '/images/recettes/Okonomiyaki.png', 2);


--
-- TOC entry 3424 (class 0 OID 38876)
-- Dependencies: 220
-- Data for Name: utilisateurs; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.utilisateurs VALUES (1, 'Toshiro', 'amhal@laposte.net', '$2a$11$3UR.cqD4nIeAtPEvL4h4x.x7P/nrZpfBj91EQQ.ZxBm1D6K9SbTvG', 'Admin');
INSERT INTO public.utilisateurs VALUES (3, 'Corazone', 'corazone@gmail.com', '$2a$11$i897KC9Kiz9YF0E5Gs2mcus/4L5eR0ROUa81wYWxa8NZVP1ArWu/u', 'Membre');
INSERT INTO public.utilisateurs VALUES (2, 'Yagamy', 'yagamy@gmail.com', '$2a$11$wBJrLJZL5MjAySmgMCB.W.AW5nwjYVyYIbNvRIXi05dh7ckEMmYlm', 'Membre');


--
-- TOC entry 3443 (class 0 OID 0)
-- Dependencies: 221
-- Name: categories_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categories_id_seq', 14, true);


--
-- TOC entry 3444 (class 0 OID 0)
-- Dependencies: 217
-- Name: ingredients_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ingredients_id_seq', 17, true);


--
-- TOC entry 3445 (class 0 OID 0)
-- Dependencies: 223
-- Name: recettes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.recettes_id_seq', 4, true);


--
-- TOC entry 3446 (class 0 OID 0)
-- Dependencies: 219
-- Name: utilisateurs_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.utilisateurs_id_seq', 3, true);


--
-- TOC entry 3264 (class 2606 OID 38927)
-- Name: avis avis_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avis
    ADD CONSTRAINT avis_pkey PRIMARY KEY (fk_recette, fk_utilisateur);


--
-- TOC entry 3256 (class 2606 OID 38894)
-- Name: categories categories_nom_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_nom_key UNIQUE (nom);


--
-- TOC entry 3258 (class 2606 OID 38892)
-- Name: categories categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);


--
-- TOC entry 3268 (class 2606 OID 38957)
-- Name: categories_recettes categories_recettes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories_recettes
    ADD CONSTRAINT categories_recettes_pkey PRIMARY KEY (fk_categorie, fk_recette);


--
-- TOC entry 3262 (class 2606 OID 38915)
-- Name: etapes etapes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etapes
    ADD CONSTRAINT etapes_pkey PRIMARY KEY (numero, fk_recette);


--
-- TOC entry 3246 (class 2606 OID 38874)
-- Name: ingredients ingredients_nom_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients
    ADD CONSTRAINT ingredients_nom_key UNIQUE (nom);


--
-- TOC entry 3248 (class 2606 OID 38872)
-- Name: ingredients ingredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients
    ADD CONSTRAINT ingredients_pkey PRIMARY KEY (id);


--
-- TOC entry 3266 (class 2606 OID 38942)
-- Name: ingredients_recettes ingredients_recettes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients_recettes
    ADD CONSTRAINT ingredients_recettes_pkey PRIMARY KEY (fk_ingredient, fk_recette);


--
-- TOC entry 3260 (class 2606 OID 38903)
-- Name: recettes recettes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recettes
    ADD CONSTRAINT recettes_pkey PRIMARY KEY (id);


--
-- TOC entry 3250 (class 2606 OID 38885)
-- Name: utilisateurs utilisateurs_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_email_key UNIQUE (email);


--
-- TOC entry 3252 (class 2606 OID 38883)
-- Name: utilisateurs utilisateurs_identifiant_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_identifiant_key UNIQUE (identifiant);


--
-- TOC entry 3254 (class 2606 OID 38881)
-- Name: utilisateurs utilisateurs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_pkey PRIMARY KEY (id);


--
-- TOC entry 3270 (class 2606 OID 38928)
-- Name: avis avis_fk_recette_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avis
    ADD CONSTRAINT avis_fk_recette_fkey FOREIGN KEY (fk_recette) REFERENCES public.recettes(id);


--
-- TOC entry 3271 (class 2606 OID 38933)
-- Name: avis avis_fk_utilisateur_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.avis
    ADD CONSTRAINT avis_fk_utilisateur_fkey FOREIGN KEY (fk_utilisateur) REFERENCES public.utilisateurs(id);


--
-- TOC entry 3274 (class 2606 OID 38958)
-- Name: categories_recettes categories_recettes_fk_categorie_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories_recettes
    ADD CONSTRAINT categories_recettes_fk_categorie_fkey FOREIGN KEY (fk_categorie) REFERENCES public.categories(id);


--
-- TOC entry 3275 (class 2606 OID 38963)
-- Name: categories_recettes categories_recettes_fk_recette_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories_recettes
    ADD CONSTRAINT categories_recettes_fk_recette_fkey FOREIGN KEY (fk_recette) REFERENCES public.recettes(id);


--
-- TOC entry 3269 (class 2606 OID 38916)
-- Name: etapes etapes_fk_recette_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etapes
    ADD CONSTRAINT etapes_fk_recette_fkey FOREIGN KEY (fk_recette) REFERENCES public.recettes(id);


--
-- TOC entry 3272 (class 2606 OID 38943)
-- Name: ingredients_recettes ingredients_recettes_fk_ingredient_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients_recettes
    ADD CONSTRAINT ingredients_recettes_fk_ingredient_fkey FOREIGN KEY (fk_ingredient) REFERENCES public.ingredients(id);


--
-- TOC entry 3273 (class 2606 OID 38948)
-- Name: ingredients_recettes ingredients_recettes_fk_recette_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ingredients_recettes
    ADD CONSTRAINT ingredients_recettes_fk_recette_fkey FOREIGN KEY (fk_recette) REFERENCES public.recettes(id);


-- Completed on 2025-09-30 15:58:46

--
-- PostgreSQL database dump complete
--





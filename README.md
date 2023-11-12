# universidadEvaluacion


1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

    ```c#
      public async Task<IEnumerable<Persona>> ObtenerListadoAlumnosAsync()
        {
            var listadoAlumnos = await _context.Personas
                .Where(p => p.IdTipoPersona == 1) 
                .OrderBy(p => p.Apellido1)
                .ThenBy(p => p.Apellido2)
                .ThenBy(p => p.Nombre)
                .Select(p => new Persona
                {
                    Apellido1 = p.Apellido1,
                    Apellido2 = p.Apellido2,
                    Nombre = p.Nombre,
                    TipoPersona = p.TipoPersona

                })
                .ToListAsync();

            return listadoAlumnos;
        }
    ```

    * Response:
      
    ```json
    [
	{
		"apellido1": "Domínguez",
		"apellido2": "Guerrero",
		"nombre": "Antonio",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Gea",
		"apellido2": "Ruiz",
		"nombre": "Sonia",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Gutiérrez",
		"apellido2": "López",
		"nombre": "Juan",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Heller",
		"apellido2": "Pagac",
		"nombre": "Pedro",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Herman",
		"apellido2": "Pacocha",
		"nombre": "Daniel",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Hernández",
		"apellido2": "Martínez",
		"nombre": "Irene",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Herzog",
		"apellido2": "Tremblay",
		"nombre": "Ramón",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Koss",
		"apellido2": "Bayer",
		"nombre": "José",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Lakin",
		"apellido2": "Yundt",
		"nombre": "Inma",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Saez",
		"apellido2": "Vega",
		"nombre": "Juan",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Sánchez",
		"apellido2": "Pérez",
		"nombre": "Salvador",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Strosin",
		"apellido2": "Turcotte",
		"nombre": "Ismael",
		"tipoPersona": "alumno"
	}
    ]
    ``` 
2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.

    ```c#
     public async Task<IEnumerable<Persona>> AlumnosSinTelefono()
        {
            return await _context.Personas
                .Where(p => p.Telefono == null && p.IdTipoPersona == 1)
                .Include(p => p.TipoPersona)
                .ToListAsync();
        }
    ```
     * Response: 
    ```json
    [
	{
		"apellido1": "Heller",
		"apellido2": "Pagac",
		"nombre": "Pedro",
		"tipoPersona": "alumno"
	},
	{
		"apellido1": "Strosin",
		"apellido2": "Turcotte",
		"nombre": "Ismael",
		"tipoPersona": "alumno"
	}
    ]
    ```
3. Devuelve el listado de los alumnos que nacieron en `1999`.

    ```c#
      public async Task<IEnumerable<Persona>> Alumnos1999()
        {
            return await _context.Personas
            .Where(p => p.IdTipoPersona == 1 && p.FechaNacimiento.Year == 1999)
            .Include(p => p.TipoPersona)
            .Include(p => p.Sexo)
            .ToListAsync();
        }
    ```
      * Response: 
    ```json
   [
	{
		"nif": "97258166K",
		"nombre": "Ismael",
		"apellido1": "Strosin",
		"apellido2": "Turcotte",
		"ciudad": "Almería",
		"direccion": "C/ Neptuno",
		"telefono": null,
		"fechaNacimiento": "1999-05-24",
		"sexo": "H",
		"tipoPersona": "alumno",
		"id": 7
	},
	{
		"nif": "41491230N",
		"nombre": "Antonio",
		"apellido1": "Domínguez",
		"apellido2": "Guerrero",
		"ciudad": "Almería",
		"direccion": "C/ Cabo de Gata",
		"telefono": "626652498",
		"fechaNacimiento": "1999-02-11",
		"sexo": "H",
		"tipoPersona": "alumno",
		"id": 22
	}
    ]
    ```
4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.

    ```c#
     public async Task<IEnumerable<Profesor>> ObtenerProfesoresnoTelefono()
        {
            return await _context.Profesores
                .Where(profesor => profesor.Persona.Telefono == null && profesor.Persona.NIF.EndsWith("K"))
                .Include(p => p.Persona)
                .ThenInclude(p => p.Sexo)
                .Include(p => p.Persona)
                .ThenInclude(p => p.TipoPersona)
                .Include(p => p.Departamento)
                .ToListAsync();            
        }
    ```
    * Response: 
    ```json
   [
	{
		"departamento": "Economía y Empresa",
		"nif": "10485008K",
		"nombre": "Antonio",
		"apellido1": "Fahey",
		"apellido2": "Considine",
		"ciudad": "Almería",
		"direccion": "C/ Sierra de los Filabres",
		"telefono": null,
		"fechaNacimiento": "1982-03-18",
		"sexo": "H",
		"tipoPersona": "profesor",
		"id": 9
	},
	{
		"departamento": "Educación",
		"nif": "85869555K",
		"nombre": "Guillermo",
		"apellido1": "Ruecker",
		"apellido2": "Upton",
		"ciudad": "Almería",
		"direccion": "C/ Sierra de Gádor",
		"telefono": null,
		"fechaNacimiento": "1973-05-05",
		"sexo": "H",
		"tipoPersona": "profesor",
		"id": 10
	}
    ]
    ```
5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.

    ```c#
       public async Task<IEnumerable<Asignatura>> ObtenerAsignaturas()
        {
            return await _context.Asignaturas
                .Where(a => a.Cuatrimestre == 1 && a.Curso == 3 && a.Id_Grado == 7)
                .Include(a => a.Profesor)
                .ThenInclude(a => a.Persona)
                .Include(a => a.TipoAsignatura)
                .Include(a => a.Grado)
                .ToListAsync();
        }
    ```
     * Response: 
    ```json
   [
	{
		"nombre": "Bases moleculares del desarrollo vegetal",
		"creditos": 4.5,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 72
	},
	{
		"nombre": "Fisiología animal",
		"creditos": 4.5,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 73
	},
	{
		"nombre": "Metabolismo y biosíntesis de biomoléculas",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 74
	},
	{
		"nombre": "Operaciones de separación",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 75
	},
	{
		"nombre": "Patología molecular de plantas",
		"creditos": 4.5,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 76
	},
	{
		"nombre": "Técnicas instrumentales básicas",
		"creditos": 4.5,
		"tipoAsignatura": "obligatoria",
		"curso": 3,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 77
	}
    ]
    ```
6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

    ```c#
      public async Task<IEnumerable<Persona>> AlumnasMatriculadasInformatica()
        {
            return await _context.AlumnoAsignaturas
                   .Where(aa => aa.Asignatura.Grado.Id == 4 && aa.Persona.IdTipoPersona == 1) 
                   .Select(aa => new Persona{
                    Id = aa.Persona.Id,
                    Nombre = aa.Persona.Nombre,
                    Apellido1 = aa.Persona.Apellido1,
                    Apellido2 = aa.Persona.Apellido2,
                    NIF = aa.Persona.NIF,
                    TipoPersona = aa.Persona.TipoPersona,
                    Sexo = aa.Persona.Sexo,
                    Ciudad = aa.Persona.Ciudad,
                    Direccion = aa.Persona.Direccion,
                    Telefono = aa.Persona.Telefono,
                    FechaNacimiento = aa.Persona.FechaNacimiento
                   })
                   .Where(p => p.Sexo.Nombre == "M")
                   .Distinct()
                   .ToListAsync();
        }
    ```
     * Response: 
    ```json
    [
	{
		"nif": "11578526G",
		"nombre": "Inma",
		"apellido1": "Lakin",
		"apellido2": "Yundt",
		"ciudad": "Almería",
		"direccion": "C/ Picos de Europa",
		"telefono": "678652431",
		"fechaNacimiento": "1998-09-01",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 19
	},
	{
		"nif": "64753215G",
		"nombre": "Irene",
		"apellido1": "Hernández",
		"apellido2": "Martínez",
		"ciudad": "Almería",
		"direccion": "C/ Zapillo",
		"telefono": "628452384",
		"fechaNacimiento": "1996-03-12",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 23
	},
	{
		"nif": "85135690V",
		"nombre": "Sonia",
		"apellido1": "Gea",
		"apellido2": "Ruiz",
		"ciudad": "Almería",
		"direccion": "C/ Mercurio",
		"telefono": "678812017",
		"fechaNacimiento": "1995-04-13",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 24
	}
    ]
    ```
7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

    ```c#
      public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasInformatica()
        {
            return await _context.Asignaturas
                .Include(a => a.Grado)
                .Include(a => a.Profesor)
                .ThenInclude(a => a.Persona)
                .Include(a => a.TipoAsignatura)
                .Where(a => a.Grado.Id == 4)
                .ToListAsync();
        }
    ```
    * Response: 
    ```json
   [
	{
		"nombre": "Estructura de Datos y Algoritmos I",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": "Cristina Lemke Rutherford",
		"grado": "Grado en Ingeniería Informática (Plan 2015)",
		"id": 12
	},
	{
		"nombre": "Ingeniería del Software",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": "Manolo Hamill Kozey",
		"grado": "Grado en Ingeniería Informática (Plan 2015)",
		"id": 13
	},
	{
		"nombre": "Sistemas Inteligentes",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": "Cristina Lemke Rutherford",
		"grado": "Grado en Ingeniería Informática (Plan 2015)",
		"id": 14
	},
	{
		"nombre": "Sistemas Operativos",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": "Manolo Hamill Kozey",
		"grado": "Grado en Ingeniería Informática (Plan 2015)",
		"id": 15
	}
   ... ]
    ```
8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

    ```c#
      public async Task<IEnumerable<Profesor>> ObtenerProfesoresconDepto()
        {
            return await _context.Profesores
            .Include(p => p.Persona)
            .OrderBy(p => p.Persona.Apellido1)
            .ThenBy(p => p.Persona.Apellido2)
            .ThenBy(p => p.Persona.Nombre)
            .Include(p => p.Departamento)
            .ToListAsync();

        }
    ```
    * Response: 
    ```json
    [
  	{
  		"primerApellido": "Fahey",
  		"segundoApellido": "Considine",
  		"nombre": "Antonio",
  		"nombreDepartamento": "Economía y Empresa"
  	},
  	{
  		"primerApellido": "Hamill",
  		"segundoApellido": "Kozey",
  		"nombre": "Manolo",
  		"nombreDepartamento": "Informática"
  	},
  	{
  		"primerApellido": "Kohler",
  		"segundoApellido": "Schoen",
  		"nombre": "Alejandro",
  		"nombreDepartamento": "Matemáticas"
  	},
  	{
  		"primerApellido": "Lemke",
  		"segundoApellido": "Rutherford",
  		"nombre": "Cristina",
  		"nombreDepartamento": "Economía y Empresa"
  	},
  	{
  		"primerApellido": "Monahan",
  		"segundoApellido": "Murray",
  		"nombre": "Micaela",
  		"nombreDepartamento": "Agronomía"
  	},
  	{
  		"primerApellido": "Ramirez",
  		"segundoApellido": "Gea",
  		"nombre": "Zoe",
  		"nombreDepartamento": "Informática"
  	},
  	{
  		"primerApellido": "Ruecker",
  		"segundoApellido": "Upton",
  		"nombre": "Guillermo",
  		"nombreDepartamento": "Educación"
  	},
  	{
  		"primerApellido": "Schmidt",
  		"segundoApellido": "Fisher",
  		"nombre": "David",
  		"nombreDepartamento": "Matemáticas"
  	},
  	{
  		"primerApellido": "Schowalter",
  		"segundoApellido": "Muller",
  		"nombre": "Francesca",
  		"nombreDepartamento": "Química y Física"
  	},
  	{
  		"primerApellido": "Spencer",
  		"segundoApellido": "Lakin",
  		"nombre": "Esther",
  		"nombreDepartamento": "Educación"
  	},
  	{
  		"primerApellido": "Stiedemann",
  		"segundoApellido": "Morissette",
  		"nombre": "Alfredo",
  		"nombreDepartamento": "Química y Física"
  	},
  	{
  		"primerApellido": "Streich",
  		"segundoApellido": "Hirthe",
  		"nombre": "Carmen",
  		"nombreDepartamento": "Educación"
  	}
      ]
    ```
9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.

    ```c#
      public async Task<IEnumerable<AlumnoAsignatura>> ObtenerAsignaturasCursoAlumno(string nif)
        {
            return await _context.AlumnoAsignaturas
                .Include(aa => aa.Asignatura)
                .Include(a => a.CursoEscolar)
                .Where(aa => aa.Persona.NIF == nif)
                .ToListAsync();
        }
    ```    
     * Response: 
    ```json
   [
	{
		"nombreAsignatura": "Álgegra lineal y matemática discreta",
		"anioInicioCurso": 2014,
		"anioFinCurso": 2015
	},
	{
		"nombreAsignatura": "Cálculo",
		"anioInicioCurso": 2014,
		"anioFinCurso": 2015
	},
	{
		"nombreAsignatura": "Física para informática",
		"anioInicioCurso": 2014,
		"anioFinCurso": 2015
	}
    ]
    ```
10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`.

     ```c#
       public async Task<IEnumerable<Profesor>> DepartamentosConProfesoresInformatica()
        {
            var departamentos = await _context.Profesores
                .Where(p => p.Asignaturas.Any(a => a.Grado.Id == 4))
                .Include(p => p.Departamento)
                .Distinct()
                .ToListAsync();

            return departamentos;
        }
     ``` 
     
  * Response: 
    ```json
     [
	{
		"nombreDepartamento": "Informática"
	},
	{
		"nombreDepartamento": "Economía y Empresa"
	}
    ]
    ```
11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.

     ```c#
       public async Task<IEnumerable<Persona>> AlumnosMatriculados2018_2019()
        {
            var alumnos = await _context.AlumnoAsignaturas
                .Where(aa => aa.CursoEscolar.AnhoInicio == 2018 && aa.CursoEscolar.AnhoFin == 2019)
                .Select(aa => new Persona
                   {
                       Id = aa.Persona.Id,
                       Nombre = aa.Persona.Nombre,
                       Apellido1 = aa.Persona.Apellido1,
                       Apellido2 = aa.Persona.Apellido2,
                       NIF = aa.Persona.NIF,
                       TipoPersona = aa.Persona.TipoPersona,
                       Sexo = aa.Persona.Sexo,
                       Ciudad = aa.Persona.Ciudad,
                       Direccion = aa.Persona.Direccion,
                       Telefono = aa.Persona.Telefono,
                       FechaNacimiento = aa.Persona.FechaNacimiento
                   })
                .Distinct()
                .ToListAsync();

            return alumnos;
        }
     ```

     * Response: 
    ```json
     [
	{
		"nif": "11578526G",
		"nombre": "Inma",
		"apellido1": "Lakin",
		"apellido2": "Yundt",
		"ciudad": "Almería",
		"direccion": "C/ Picos de Europa",
		"telefono": "678652431",
		"fechaNacimiento": "1998-09-01",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 19
	},
	{
		"nif": "64753215G",
		"nombre": "Irene",
		"apellido1": "Hernández",
		"apellido2": "Martínez",
		"ciudad": "Almería",
		"direccion": "C/ Zapillo",
		"telefono": "628452384",
		"fechaNacimiento": "1996-03-12",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 23
	},
	{
		"nif": "85135690V",
		"nombre": "Sonia",
		"apellido1": "Gea",
		"apellido2": "Ruiz",
		"ciudad": "Almería",
		"direccion": "C/ Mercurio",
		"telefono": "678812017",
		"fechaNacimiento": "1995-04-13",
		"sexo": "M",
		"tipoPersona": "alumno",
		"id": 24
	}
    ]
    ```
12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.

     ```c#
       public async Task<IEnumerable<Profesor>> ListadoProfesoresDepartamentos()
        {
            var listadoProfesores = await _context.Profesores
                .Include(p => p.Persona)
                .Include(p => p.Departamento)
                .OrderBy(p => p.Departamento.Nombre)
                .ThenBy(p => p.Persona.Apellido1)
                .ThenBy(p => p.Persona.Apellido2)
                .ThenBy(p => p.Persona.Nombre)
                .ToListAsync();

            return listadoProfesores;
        }
     ```
       * Response: 
    ```json
     [
	{
		"primerApellido": "Fahey",
		"segundoApellido": "Considine",
		"nombre": "Antonio",
		"nombreDepartamento": "Economía y Empresa"
	},
	{
		"primerApellido": "Hamill",
		"segundoApellido": "Kozey",
		"nombre": "Manolo",
		"nombreDepartamento": "Informática"
	},
	{
		"primerApellido": "Kohler",
		"segundoApellido": "Schoen",
		"nombre": "Alejandro",
		"nombreDepartamento": "Matemáticas"
	},
	{
		"primerApellido": "Lemke",
		"segundoApellido": "Rutherford",
		"nombre": "Cristina",
		"nombreDepartamento": "Economía y Empresa"
	},
	{
		"primerApellido": "Monahan",
		"segundoApellido": "Murray",
		"nombre": "Micaela",
		"nombreDepartamento": "Agronomía"
	},
	{
		"primerApellido": "Ramirez",
		"segundoApellido": "Gea",
		"nombre": "Zoe",
		"nombreDepartamento": "Informática"
	},
	{
		"primerApellido": "Ruecker",
		"segundoApellido": "Upton",
		"nombre": "Guillermo",
		"nombreDepartamento": "Educación"
	},
	{
		"primerApellido": "Schmidt",
		"segundoApellido": "Fisher",
		"nombre": "David",
		"nombreDepartamento": "Matemáticas"
	},
	{
		"primerApellido": "Schowalter",
		"segundoApellido": "Muller",
		"nombre": "Francesca",
		"nombreDepartamento": "Química y Física"
	},
	{
		"primerApellido": "Spencer",
		"segundoApellido": "Lakin",
		"nombre": "Esther",
		"nombreDepartamento": "Educación"
	},
	{
		"primerApellido": "Stiedemann",
		"segundoApellido": "Morissette",
		"nombre": "Alfredo",
		"nombreDepartamento": "Química y Física"
	},
	{
		"primerApellido": "Streich",
		"segundoApellido": "Hirthe",
		"nombre": "Carmen",
		"nombreDepartamento": "Educación"
	}
    ]
    ```
13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.

     ```c#
       public async Task<IEnumerable<Profesor>> ObtenerProfesoresSinDepartamento()
        {
            var profesoresSinDepartamento = await _context.Profesores
                .Where(p => p.Departamento == null)
                .ToListAsync();

            return profesoresSinDepartamento;
        }
     ```

      ```c#
       public async Task<IEnumerable<Departamento>> ObtenerDepartamentosSinProfesores()
        {
            var departamentosSinProfesores = await _context.Departamentos
                .Where(d => !d.Profesores.Any()) 
                .ToListAsync();

            return departamentosSinProfesores;
        }
     ```

       * Response: 
    ```json
     [
    ]
    ```

     ```json
     [
	{
		"nombre": "Filología",
		"id": 7
	},
	{
		"nombre": "Derecho",
		"id": 8
	},
	{
		"nombre": "Biología y Geología",
		"id": 9
	}
    ]
    ```
14. Devuelve un listado con los profesores que no imparten ninguna asignatura.

     ```c#
     public async Task<IEnumerable<Profesor>> ObtenerProfesoresSinAsignaturas()
        {
            var profesoresSinAsignaturas = await _context.Profesores
                .Where(p => !p.Asignaturas.Any())
                .ToListAsync();

            return profesoresSinAsignaturas;
        }
     ```
       * Response: 
    ```json
    [
	{
		"departamento": "Economía y Empresa",
		"nif": "10485008K",
		"nombre": "Antonio",
		"apellido1": "Fahey",
		"apellido2": "Considine",
		"ciudad": "Almería",
		"direccion": "C/ Sierra de los Filabres",
		"telefono": null,
		"fechaNacimiento": "1982-03-18",
		"sexo": null,
		"tipoPersona": null,
		"id": 9
	},
	{
		"departamento": "Informática",
		"nif": "82937751G",
		"nombre": "Manolo",
		"apellido1": "Hamill",
		"apellido2": "Kozey",
		"ciudad": "Almería",
		"direccion": "C/ Duero",
		"telefono": "950263514",
		"fechaNacimiento": "1977-01-02",
		"sexo": null,
		"tipoPersona": null,
		"id": 7
	},
	{
		"departamento": "Matemáticas",
		"nif": "80502866Z",
		"nombre": "Alejandro",
		"apellido1": "Kohler",
		"apellido2": "Schoen",
		"ciudad": "Almería",
		"direccion": "C/ Tajo",
		"telefono": "668726354",
		"fechaNacimiento": "1980-03-14",
		"sexo": null,
		"tipoPersona": null,
		"id": 8
	},
	{
		"departamento": "Economía y Empresa",
		"nif": "79503962T",
		"nombre": "Cristina",
		"apellido1": "Lemke",
		"apellido2": "Rutherford",
		"ciudad": "Almería",
		"direccion": "C/ Saturno",
		"telefono": "669162534",
		"fechaNacimiento": "1977-08-21",
		"sexo": null,
		"tipoPersona": null,
		"id": 3
	},
	{
		"departamento": "Agronomía",
		"nif": "04326833G",
		"nombre": "Micaela",
		"apellido1": "Monahan",
		"apellido2": "Murray",
		"ciudad": "Almería",
		"direccion": "C/ Veleta",
		"telefono": "662765413",
		"fechaNacimiento": "1976-02-25",
		"sexo": null,
		"tipoPersona": null,
		"id": 11
	},
	{
		"departamento": "Informática",
		"nif": "11105554G",
		"nombre": "Zoe",
		"apellido1": "Ramirez",
		"apellido2": "Gea",
		"ciudad": "Almería",
		"direccion": "C/ Marte",
		"telefono": "618223876",
		"fechaNacimiento": "1979-08-19",
		"sexo": null,
		"tipoPersona": null,
		"id": 1
	},
	{
		"departamento": "Educación",
		"nif": "85869555K",
		"nombre": "Guillermo",
		"apellido1": "Ruecker",
		"apellido2": "Upton",
		"ciudad": "Almería",
		"direccion": "C/ Sierra de Gádor",
		"telefono": null,
		"fechaNacimiento": "1973-05-05",
		"sexo": null,
		"tipoPersona": null,
		"id": 10
	},
	{
		"departamento": "Matemáticas",
		"nif": "38223286T",
		"nombre": "David",
		"apellido1": "Schmidt",
		"apellido2": "Fisher",
		"ciudad": "Almería",
		"direccion": "C/ Venus",
		"telefono": "678516294",
		"fechaNacimiento": "1978-01-19",
		"sexo": null,
		"tipoPersona": null,
		"id": 2
	},
	{
		"departamento": "Química y Física",
		"nif": "79221403L",
		"nombre": "Francesca",
		"apellido1": "Schowalter",
		"apellido2": "Muller",
		"ciudad": "Almería",
		"direccion": "C/ Quinto pino",
		"telefono": null,
		"fechaNacimiento": "1980-10-31",
		"sexo": null,
		"tipoPersona": null,
		"id": 12
	},
	{
		"departamento": "Educación",
		"nif": "61142000L",
		"nombre": "Esther",
		"apellido1": "Spencer",
		"apellido2": "Lakin",
		"ciudad": "Almería",
		"direccion": "C/ Plutón",
		"telefono": null,
		"fechaNacimiento": "1977-05-19",
		"sexo": null,
		"tipoPersona": null,
		"id": 4
	},
	{
		"departamento": "Química y Física",
		"nif": "73571384L",
		"nombre": "Alfredo",
		"apellido1": "Stiedemann",
		"apellido2": "Morissette",
		"ciudad": "Almería",
		"direccion": "C/ Guadalquivir",
		"telefono": "950896725",
		"fechaNacimiento": "1980-02-01",
		"sexo": null,
		"tipoPersona": null,
		"id": 6
	},
	{
		"departamento": "Educación",
		"nif": "85366986W",
		"nombre": "Carmen",
		"apellido1": "Streich",
		"apellido2": "Hirthe",
		"ciudad": "Almería",
		"direccion": "C/ Almanzora",
		"telefono": null,
		"fechaNacimiento": "1971-04-29",
		"sexo": null,
		"tipoPersona": null,
		"id": 5
	}
    ]
    ```
15. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

     ```c#
       public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasSinProfesor()
        {
            var asignaturasSinProfesor = await _context.Asignaturas
                .Where(a => a.Profesor == null)
                .Include(a => a.Grado)
                .Include(a => a.TipoAsignatura)
                .ToListAsync();

            return asignaturasSinProfesor;
        }
     ```
       * Response: 
    ```json
    [
	{
		"nombre": "Botánica agrícola",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 62
	},
	{
		"nombre": "Fisiología vegetal",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 63
	},
	{
		"nombre": "Genética molecular",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 64
	},
	{
		"nombre": "Ingeniería bioquímica",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 65
	},
	{
		"nombre": "Termodinámica y cinética química aplicada",
		"creditos": 6,
		"tipoAsignatura": "obligatoria",
		"curso": 2,
		"cuatrimestre": 1,
		"profesor": null,
		"grado": "Grado en Biotecnología (Plan 2015)",
		"id": 66
	}, ...
    ```
16. Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca.

     ```c#
       public async Task<IEnumerable<object>> ObtenerAsignaturasNoImpartidas()
        {
            var resultado = await _context.Asignaturas
                .Where(asignatura => !asignatura.AlumnoAsignaturas.Any())
                .Select(asignatura => new
                {
                    NombreDepartamento = asignatura.Profesor.Departamento.Nombre,
                    AsignaturaNoImpartida = asignatura.Nombre
                })
                .ToListAsync();

            return resultado.Cast<object>();
        }
     ```

       * Response: 
    ```json
     [
	{
		"nombreDepartamento": "Informática"
	},
	{
		"nombreDepartamento": "Economía y Empresa"
	}
    ]
    ```


17. Devuelve el número total de **alumnas** que hay.

     ```c#
       public async Task<int> ObtenerNumeroTotalAlumnas()
        {
            return await _context.Personas
                .CountAsync(p => p.IdTipoPersona == 1 && p.Sexo.Nombre == "M");
        }
     ```
18. Calcula cuántos alumnos nacieron en `1999`.

     ```c#
       public async Task<int> ContarAlumnosNacidosEn1999()
        {
            return await _context.Personas
                .Where(p => p.IdTipoPersona == 1 && p.FechaNacimiento.Year == 1999)
                .CountAsync();
        }
     ```
19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

     ```c#
        public async Task<IEnumerable<object>> ObtenerProfesoresPorDepartamento()
        {
            var resultado = await _context.Departamentos
                .Where(depto => depto.Profesores.Any())
                .Select(depto => new
                {
                    NombreDepartamento = depto.Nombre,
                    NumeroProfesores = depto.Profesores.Count
                })
                .OrderByDescending(depto => depto.NumeroProfesores)
                .ToListAsync();

            return resultado;
        }
     ```
20. Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.

     ```c#
        public async Task<IEnumerable<object>> NumeroProfesoresPorDepartamento()
        {
            var resultado = await _context.Departamentos
                .Select(depto => new
                {
                    NombreDepartamento = depto.Nombre,
                    NumeroProfesores = depto.Profesores.Count
                })
                .ToListAsync();

            return resultado;
        }
     ```
21. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas.

     ```c#
       public async Task<IEnumerable<object>> NumeroAsignaturasPorGrado()
        {
            var resultado = await _context.Grados
                .Select(grado => new
                {
                    NombreGrado = grado.Nombre,
                    NumeroAsignaturas = grado.Asignaturas.Count
                })
                .OrderByDescending(x => x.NumeroAsignaturas)
                .ToListAsync();

            return resultado;
        }
     ```
22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.

     ```c#
      public async Task<IEnumerable<object>> GradosConMasDe40Asignaturas()
        {
            var resultado = await _context.Grados
                .Where(grado => grado.Asignaturas.Count > 40)
                .Select(grado => new
                {
                    NombreGrado = grado.Nombre,
                    NumeroAsignaturas = grado.Asignaturas.Count
                })
                .ToListAsync();

            return resultado;
        }
     ```
23. Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de crédidos.

     ```c#
       public async Task<IEnumerable<object>> SumaCreditos()
        {
            var resultado = await _context.Grados
                .SelectMany(grado => grado.Asignaturas
                    .GroupBy(asignatura => asignatura.TipoAsignatura.Nombre)
                    .Select(grupo => new
                    {
                        NombreGrado = grado.Nombre,
                        TipoAsignatura = grupo.Key,
                        SumaCreditos = grupo.Sum(asignatura => asignatura.Creditos)
                    }))
                .OrderByDescending(item => item.SumaCreditos)
                .ToListAsync();

            return resultado;
        }
     ```
24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.

     ```c#
      public async Task<IEnumerable<object>> AlumnosMatriculados()
        {
            var resultado = await _context.CursosEscolares
                .Select(curso => new
                {
                    AnioInicioCurso = curso.AnhoInicio,
                    NumeroAlumnosMatriculados = curso.AlumnoAsignaturas.Select(aa => aa.Id_alumno).Distinct().Count()
                })
                .ToListAsync();

            return resultado;
        }

     ```
25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

     ```c#
       public async Task<IEnumerable<object>> NumeroAsignaturasPorProfesor()
        {
            var resultado = await _context.Profesores
                .Select(profesor => new
                {
                    Id = profesor.Id,
                    Nombre = profesor.Persona.Nombre,
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    NumeroAsignaturas = profesor.Asignaturas.Count()
                })
                .OrderByDescending(profesor => profesor.NumeroAsignaturas)
                .ToListAsync();

            return resultado;
        }
     ```
26. Devuelve todos los datos del alumno más joven.

     ```c#
        public async Task<Persona> AlumnoMasJoven()
        {
            var alumnoMasJoven = await _context.Personas
                .Where(persona => persona.IdTipoPersona == 1)
                .OrderByDescending(persona => persona.FechaNacimiento)
                .Include(persona => persona.Sexo)
                .Include(persona => persona.TipoPersona)
                .FirstOrDefaultAsync();

            return alumnoMasJoven;
        }
     ```
27. Devuelve un listado con los profesores que no están asociados a un departamento.

       ```c#
       public async Task<IEnumerable<Profesor>> ObtenerProfesoresSinDepartamento()
        {
            var profesoresSinDepartamento = await _context.Profesores
                .Where(p => p.Departamento == null)
                .ToListAsync();

            return profesoresSinDepartamento;
        }
     ```
28. Devuelve un listado con los departamentos que no tienen profesores asociados.
      ```c#
       public async Task<IEnumerable<Departamento>> ObtenerDepartamentosSinProfesores()
        {
            var departamentosSinProfesores = await _context.Departamentos
                .Where(d => !d.Profesores.Any()) 
                .ToListAsync();

            return departamentosSinProfesores;
        }
     ```
29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.

     ```c#
        public async Task<IEnumerable<Profesor>> ProfesoresSinAsignaturas()
        {
            var profesoresSinAsignaturas = await _context.Profesores
                .Where(profesor => profesor.Id_departamento != null && !profesor.Asignaturas.Any())
                .Include(profesor => profesor.Persona)
                .ThenInclude(profesor => profesor.Sexo)
                .Include(profesor => profesor.Persona)
                .ThenInclude(profesor => profesor.TipoPersona)
                .Include(profesor => profesor.Departamento)
                .ToListAsync();

            return profesoresSinAsignaturas;
        }
     ```
30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

     ```c#
        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasSinProfesor()
        {
            var asignaturasSinProfesor = await _context.Asignaturas
                .Where(a => a.Profesor == null)
                .Include(a => a.Grado)
                .Include(a => a.TipoAsignatura)
                .ToListAsync();

            return asignaturasSinProfesor;
        }
     ```
31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

     ```c#
       public async Task<IEnumerable<Departamento>> DepartamentosSinAsignaturascurso()
        {
            var departamentosSinAsignaturasImpartidas = await _context.Departamentos
            .Where(d => d.Profesores.Any())
            .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any(a => a.Id_Profesor != null && _context.AlumnoAsignaturas.Any(asm => asm.Id_asignatura == a.Id && asm.Id_curso_escolar != null))))
            .ToListAsync();
            return departamentosSinAsignaturasImpartidas;
        }
     ```
     

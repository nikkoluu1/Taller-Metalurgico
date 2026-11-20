import { useEffect, useState } from 'react'

type VersionApi = {
  nombre: string
  version: string
}

function App() {
  const [version, setVersion] = useState<VersionApi | null>(null)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    fetch('/api/version')
      .then((res) => {
        if (!res.ok) throw new Error(`HTTP ${res.status}`)
        return res.json() as Promise<VersionApi>
      })
      .then(setVersion)
      .catch((e: Error) => setError(e.message))
  }, [])

  return (
    <main className="contenedor">
      <h1>Taller Metalúrgico</h1>
      <p>Sistema de gestión: inventario, tareas, proveedores y recordatorios.</p>
      <section className="estado">
        {version && (
          <p>
            Conectado a <strong>{version.nombre}</strong> v{version.version}
          </p>
        )}
        {error && <p className="error">No se pudo conectar con la API ({error}).</p>}
        {!version && !error && <p>Conectando con la API…</p>}
      </section>
    </main>
  )
}

export default App

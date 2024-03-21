using UnityEngine;

public class Wander : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del agente
    public float radioWander = 5f; // Radio del c�rculo de wander
    public float distanciaWander = 10f; // Distancia m�xima a la que el agente puede ver
    public float cambioDireccionIntervalo = 1f; // Intervalo de tiempo para cambiar la direcci�n de wander

    private Vector3 objetivoWander;
    private float tiempoUltimoCambioDireccion;

    void Start()
    {
        // Inicializar el primer objetivo de wander
        objetivoWander = ObtenerNuevoObjetivoWander();
        tiempoUltimoCambioDireccion = Time.time;
    }

    void Update()
    {
        // Verificar si es tiempo de cambiar la direcci�n de wander
        if (Time.time - tiempoUltimoCambioDireccion > cambioDireccionIntervalo)
        {
            objetivoWander = ObtenerNuevoObjetivoWander();
            tiempoUltimoCambioDireccion = Time.time;
        }

        // Mover el agente hacia el objetivo wander
        Vector3 direccion = (objetivoWander - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;

        // Rotar hacia la direcci�n de movimiento
        if (direccion != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direccion);
            transform.rotation = rotation;
        }
    }

    Vector3 ObtenerNuevoObjetivoWander()
    {
        // Generar un punto aleatorio dentro del c�rculo de wander
        Vector3 puntoAleatorio = Random.insideUnitCircle.normalized * radioWander;

        // Desplazar el punto aleatorio a una distancia dentro del rango de visi�n del agente
        puntoAleatorio *= distanciaWander;

        // Ajustar el punto aleatorio para que est� en el mismo plano que el agente
        puntoAleatorio += transform.position;

        return puntoAleatorio;
    }
}
